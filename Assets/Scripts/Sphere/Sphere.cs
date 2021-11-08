using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TestTask.SphereNS
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(SphereCollider))]
    public class Sphere : MonoBehaviour, IPointerClickHandler
    {
        private SphereData _data;
        private float _y;

        public SphereData Data => _data;
        public float Y => _y;

        public event UnityAction<Sphere> SphereClicked;

        public void Initialize(SphereData data)
        {
            GetComponent<MeshRenderer>().material.color = data.Color;
            _data = data;
        }

        private void Update()
        {
            Fall();
        }

        private void Fall()
        {
            Vector3 position = transform.position;

            position.y -= _data.Velocity * Time.deltaTime;
            _y = position.y;

            transform.position = position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SphereClicked?.Invoke(this);
        }
    }
}
