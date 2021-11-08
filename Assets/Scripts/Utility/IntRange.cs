using UnityEngine;

namespace TestTask.Utility
{
    [System.Serializable]
    public struct IntRange
    {
        [SerializeField]
        private int _min;
        [SerializeField]
        private int _max;

        public int RandomValueInRange => Random.Range(_min, _max);

        public IntRange(int min, int max)
        {
            _min = max > min ? min : max;
            _max = min < max ? max : min; 
        }
    }
}