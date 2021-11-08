using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TestTask.UI
{
    public class RestartWindow : MonoBehaviour
    {
        [SerializeField]
        protected Button _restartButton;

        [SerializeField]
        protected Text _highscore;

        public event UnityAction Restarted;

        public void SetHighscore(int highscore)
        {
            _highscore.text = "Highscore: " + highscore.ToString();
        }

        protected virtual void Restart()
        {
            Restarted?.Invoke();
        }
    }
}
