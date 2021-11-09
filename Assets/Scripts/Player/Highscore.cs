using UnityEngine;

namespace TestTask.PlayerNS
{
    public class Highscore : MonoBehaviour
    {
        private int _value;

        public int Value => _value;

        public void SetHighscore(int value)
        {
            if(value > _value)
            {
                _value = value;
            }
        }
    }
}
