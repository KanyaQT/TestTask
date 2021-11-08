using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI
{
    public abstract class ValueDisplay<T> : MonoBehaviour
    {
        [SerializeField]
        private Text _display;

        private const string DefaultText = "No text found!";

        private void Awake()
        {
            _display.text = DefaultText;
        }

        public void DisplayValue(T value)
        {
            _display.text = value.ToString();
        }
    }
}
