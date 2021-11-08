using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TestTask.Core
{
    public class Difficulty : MonoBehaviour
    {
        [SerializeField]
        private DifficultyConfig _config;
        [SerializeField, Range(0.5f, 10)]
        private float _difficultyTickInSeconds;

        public static float VelocityBonus { get; private set; }
        public static float SpawnRateDecrease { get; private set; }

        public static float MaxVelocity { get; private set; }

        public static float MinSpawnTime { get; private set; }

        private void Start()
        {
            MaxVelocity = _config.MaxVelocity;
            MinSpawnTime = _config.MinSpawnCooldown;

            StartCoroutine(IncreaseDifficulty());
        }

        private IEnumerator IncreaseDifficulty()
        {
            while(true)
            {
                DifficultyTick();
                yield return new WaitForSeconds(_difficultyTickInSeconds);
            }    
        }

        private void DifficultyTick()
        {
            VelocityBonus += _config.VelocityBonusPerSecond * _difficultyTickInSeconds;
            SpawnRateDecrease += _config.SpawnRateDecreasePerSecond * _difficultyTickInSeconds;
        }

        public void ResetDifficulty()
        {
            StopCoroutine(IncreaseDifficulty());
            VelocityBonus = 0;
            SpawnRateDecrease = 0;
            StartCoroutine(IncreaseDifficulty());
        }
    }
}
