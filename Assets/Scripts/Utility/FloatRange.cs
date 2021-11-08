using UnityEngine;

namespace TestTask.Utility
{
    [System.Serializable]
    public struct FloatRange
    {
        [SerializeField]
        private float _max;
        [SerializeField]
        private float _min;
        public float RandomValueInRange => Random.Range(_min, _max);

        public FloatRange(float min, float max)
        {
            _min = max > min ? min : max;
            _max = min < max ? max : min;
        }
    }
}