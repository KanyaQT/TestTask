using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TestTask.UI
{
    public class GameEndWindow : RestartWindow
    {
        [SerializeField]
        private Text _achievedScore;

        public void SetAchievedScore(int score)
        {
            _achievedScore.text = "Score achieved: " + score.ToString();
        }

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
        }
    }
}
