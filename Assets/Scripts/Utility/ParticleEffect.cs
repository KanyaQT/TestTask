using UnityEngine;

namespace TestTask.Utility
{
    public class ParticleEffect : DestroyAfterTimeout
    {
        [SerializeField]
        private ParticleSystem _effect;

        public void Initialize(Color color, Vector3 position)
        {
            _effect.startColor = color;
            transform.position = position;
            _effect.Play();
        }
    }
}
