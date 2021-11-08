using TestTask.UI;
using UnityEngine;

namespace TestTask.Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        private Game _game;
        [SerializeField]
        private PauseWindow _pauseWindow;
        [SerializeField]
        private GameEndWindow _gameEndWindow;
        [SerializeField]
        private PauseButton _pauseButton;

        private void OnEnable()
        {
            _pauseButton.Paused += OnPause;
            _pauseWindow.Resumed += OnResume;
            _pauseWindow.Restarted += OnRestart;
            _gameEndWindow.Restarted += OnRestart;
        }
        private void OnDisable()
        {
            _pauseButton.Paused -= OnPause;
            _pauseWindow.Resumed -= OnResume;
            _pauseWindow.Restarted -= OnRestart;
            _gameEndWindow.Restarted -= OnRestart;
        }

        private void OnPause()
        {
            _game.Pause();
        }

        private void OnResume()
        {
            _game.Resume();
        }

        private void OnRestart()
        {
            _game.Restart();
        }
    }
}
