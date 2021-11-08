using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TestTask.UI
{
    public class WindowShower : MonoBehaviour
    {
        [SerializeField]
        private PauseWindow _pauseWindow;
        [SerializeField]
        private GameEndWindow _gameEndWindow;

        public void ShowPauseWindow(int highscore)
        {
            _pauseWindow.SetHighscore(highscore);
            _pauseWindow.gameObject.SetActive(true);
        }

        public void ShowGameEndWindow(int highscore, int achievedScore)
        {
            _gameEndWindow.SetHighscore(highscore);
            _gameEndWindow.SetAchievedScore(achievedScore);
            _gameEndWindow.gameObject.SetActive(true);
        }

        public void HideWindows()
        {
            _pauseWindow.gameObject.SetActive(false);
            _gameEndWindow.gameObject.SetActive(false);
        }
    }
}