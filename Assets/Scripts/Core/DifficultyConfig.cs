using UnityEngine;

namespace TestTask.Core
{
    [CreateAssetMenu (menuName = "Config/Difficulty", order = 51)]
    public class DifficultyConfig : ScriptableObject
    {
        [SerializeField, Range(1f, 60f)]
        private float _velocityPerMinute;
        [SerializeField, Range(30f, 200f)]
        private int _spheresPerMinute;

        [SerializeField, Range(5f, 20f)]
        private float _maxVelocity;

        public float VelocityBonusPerSecond => _velocityPerMinute / 60;
        public int SpheresPerMinute => _spheresPerMinute;

        public float MaxVelocity => _maxVelocity;
    }
}
