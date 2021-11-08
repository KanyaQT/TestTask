using UnityEngine;

namespace TestTask.SphereNS
{
    public struct SphereData
    {
        private float _velocity;
        private Color _color;

        private int _rewardPoints;
        private int _damage;

        public Color Color => _color;
        public float Velocity => _velocity;
        public int RewardPoints => _rewardPoints;
        public int Damage => _damage;

        public SphereData(float velocity, Color color,
            int rewardPoints, int damage)
        {
            _velocity = velocity;
            _color = color;
            _rewardPoints = rewardPoints;
            _damage = damage;
        }
    }
}
