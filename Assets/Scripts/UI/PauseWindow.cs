using TestTask.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TestTask.UI
{
    public class PauseWindow : RestartWindow
    {
        [SerializeField]
        private Button _resumeButton;

        public event UnityAction Resumed;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(Restart);
        }

        private void Resume()
        {
            Resumed?.Invoke();
        }

        protected override void Restart()
        {
            base.Restart();
        }
    }
}
