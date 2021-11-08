using TestTask.SphereNS;
using TestTask.PlayerNS;
using UnityEngine;

namespace TestTask.Core
{
    public class PlayerSphereConnector : MonoBehaviour
    {
        [SerializeField]
        private Game _game;
        [SerializeField]
        private Player _player;
        [SerializeField]
        private SphereSpawner _spawner;

        private void OnEnable()
        {
            _spawner.SphereDestroyed += OnSphereDestroyed;
            Player.PlayerDied += OnPlayerDied;
        }

        private void OnDisable()
        {
            _spawner.SphereDestroyed -= OnSphereDestroyed;
            Player.PlayerDied -= OnPlayerDied;
        }

        private void OnSphereDestroyed(Sphere sphere)
        {
            _player.EarnPoints(sphere.Data.RewardPoints);
            DestroySphere(sphere);
        }

        private void OnPlayerDied()
        {
            _game.ShowGameEndWindow();
        }

        private void Update()
        {
            HandleSpheresBelowScreen();
        }

        private void HandleSpheresBelowScreen()
        {
            Sphere[] spheresBelow = _spawner.SpheresBelowScreen;
            int length = spheresBelow.Length;

            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    Sphere s = spheresBelow[i];
                    DamagePlayer(s.Data.Damage);
                    DestroySphere(s);
                }
            }
        }

        private void DestroySphere(Sphere s)
        {
            _spawner.DestroySphere(s);
        }

        private void DamagePlayer(int damage)
        {
            _player.TakeDamage(damage);
        }
    }
}
