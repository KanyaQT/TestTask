using TestTask.SphereNS;
using TestTask.PlayerNS;
using TestTask.UI;
using UnityEngine;

namespace TestTask.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Player _player;
        [SerializeField]
        private Highscore _highscore;
        [SerializeField]
        private SphereSpawner _spawner;
        [SerializeField]
        private WindowShower _shower;
        [SerializeField]
        private Difficulty _difficulty;

        public void ShowGameEndWindow()
        {
            if (_player.Points > _highscore.Value)
            {
                _highscore.SetHighscore(_player.Points);
            }
            _shower.ShowGameEndWindow(_highscore.Value, _player.Points);

            Time.timeScale = 0;
        }

        public void Pause()
        {
            _shower.ShowPauseWindow(_highscore.Value);
            Time.timeScale = 0;
        }

        public void Resume()
        {
            _shower.HideWindows();
            Time.timeScale = 1;   
        }

        public void Restart()
        {
            _difficulty.ResetDifficulty();
            _player.ResetValues();
            _spawner.ResetSpawner();

            Resume();
        }
    }
}
