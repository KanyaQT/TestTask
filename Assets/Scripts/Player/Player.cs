using TestTask.UI;
using UnityEngine;
using UnityEngine.Events;

namespace TestTask.PlayerNS
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerConfig _config;
        [SerializeField]
        private IntDisplay _healthDisplay;
        [SerializeField]
        private IntDisplay _scoreDisplay;

        private int _health;
        private int _points;

        public int Points => _points;

        public static event UnityAction PlayerDied;

        private void Start()
        {
            _health = _config.StartingHealth;

            _healthDisplay.DisplayValue(_health);
            _scoreDisplay.DisplayValue(0);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                _healthDisplay.DisplayValue(0);
                PlayerDied?.Invoke();
            }
            else
            {
                _healthDisplay.DisplayValue(_health);
            }
        }

        public void EarnPoints(int points)
        {
            _points += points;
            _scoreDisplay.DisplayValue(_points);
        }

        public void ResetValues()
        {
            _health = _config.StartingHealth;
            _points = 0;

            _healthDisplay.DisplayValue(_health);
            _scoreDisplay.DisplayValue(_points);
        }
    }
}
