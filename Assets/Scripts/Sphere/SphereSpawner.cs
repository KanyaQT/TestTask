using TestTask.Core;
using TestTask.Factories;
using TestTask.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace TestTask.SphereNS
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField]
        private SphereFactory _factory;
        [SerializeField]
        private EffectFactory _effectFactory;
        [SerializeField, Range(1f, 3f)]
        private int _initialSpawnCooldown;
        [SerializeField, Range(1f, 30f)]
        private int _spawnCooldown;

        private SphereStorage _storage;

        private Camera _camera;

        private float _currentCooldown;

        private const float XOffset = 5;
        private const float YOffset = 2;
        private const float ZOffset = 10;

        public event UnityAction<Sphere> SphereDestroyed;

        private float BelowScreenY => _camera.ScreenToWorldPoint(
            new Vector3(0, 0, ZOffset)).y - YOffset;
        public Sphere[] SpheresBelowScreen => _storage.GetSpheresBelowScreen(BelowScreenY);

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _storage = new SphereStorage();
            _currentCooldown = _initialSpawnCooldown;
        }

        private void Update()
        {
            if(_currentCooldown <= 0)
            {
                int count = Difficulty.SpheresPerMinute / _spawnCooldown;

                for(int i = 0; i < count; i++)
                {
                    Spawn();
                }

                _currentCooldown = _spawnCooldown;
            }

            _currentCooldown -= Time.deltaTime;
        }

        private void Spawn()
        {
            Sphere sphere = _factory.Create();
            sphere.transform.localPosition = GetRandomSpawnPosition();
            sphere.SphereClicked += OnSphereClicked;
            _storage.AddSphere(sphere);
        }

        public void DestroySphere(Sphere sphere)
        {
            sphere.SphereClicked -= OnSphereClicked;
            _storage.RemoveSphere(sphere);

            ParticleEffect effect = _effectFactory.Create();
            effect.Initialize(sphere.Data.Color, sphere.transform.position);

            _factory.Recycle(sphere);
        }

        private void OnSphereClicked(Sphere s)
        {
            SphereDestroyed?.Invoke(s);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector3 screenPoint = Vector3.zero;
            screenPoint.y = Screen.height;
            screenPoint.x = Random.Range(XOffset, Screen.width - XOffset);
            screenPoint.z += ZOffset;

            Vector3 result = _camera.ScreenToWorldPoint(screenPoint);
            return result;
        }

        public void ResetSpawner()
        {
            _currentCooldown = _initialSpawnCooldown;
            _storage.Clear(_factory);
        }
    }
}
