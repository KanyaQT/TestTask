using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TestTask.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        public event UnityAction Paused;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Paused?.Invoke();
        }
    }
}
