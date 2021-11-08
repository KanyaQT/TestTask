using UnityEngine;

namespace TestTask.Core
{
    [CreateAssetMenu (menuName = "Config/Difficulty", order = 51)]
    public class DifficultyConfig : ScriptableObject
    {
        [SerializeField, Range(0.005f, 1f)]
        private float _velocityIncreasePerSecond;
        [SerializeField, Range(0.001f, 0.1f)]
        private float _spawnRateDecreasePerSecond;

        [SerializeField, Range(5f, 20f)]
        private float _maxVelocity;
        [SerializeField, Range(0.1f, 2f)]
        private float _minSpawnCooldown;

        public float VelocityBonusPerSecond => _velocityIncreasePerSecond;
        public float SpawnRateDecreasePerSecond => _spawnRateDecreasePerSecond;

        public float MaxVelocity => _maxVelocity;
        public float MinSpawnCooldown => _minSpawnCooldown;
    }
}
