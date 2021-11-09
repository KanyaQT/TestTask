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
        public static int SpheresPerMinute { get; private set; }

        public static float MaxVelocity { get; private set; }

        private void Start()
        {
            SpheresPerMinute = _config.SpheresPerMinute;
            MaxVelocity = _config.MaxVelocity;

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
        }

        public void ResetDifficulty()
        {
            StopAllCoroutines();
            VelocityBonus = 0;
            StartCoroutine(IncreaseDifficulty());
        }
    }
}
