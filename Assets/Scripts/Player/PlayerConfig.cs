using UnityEngine;

namespace TestTask.PlayerNS
{
    [CreateAssetMenu (menuName = "Config/Player", order = 51)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Range(1, 100)]
        private int _startingHealth;

        public int StartingHealth => _startingHealth;
    }
}
