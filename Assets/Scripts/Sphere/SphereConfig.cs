using TestTask.Utility;
using UnityEngine;

namespace TestTask.SphereNS
{
    [CreateAssetMenu(menuName = "Config/Sphere", order = 51)]
    public class SphereConfig : ScriptableObject
    {
        [SerializeField]
        private FloatRange _velocityRange;
        [SerializeField]
        private Gradient _colorRange;
        [SerializeField]
        private IntRange _rewardPointsRange;
        [SerializeField]
        private IntRange _damageRange;

        public float Velocity => _velocityRange.RandomValueInRange;
        public Color Color => _colorRange.Evaluate(Random.Range(0f, 1f));
        public int RewardPoints => _rewardPointsRange.RandomValueInRange;
        public int Damage => _damageRange.RandomValueInRange;
    }
}
