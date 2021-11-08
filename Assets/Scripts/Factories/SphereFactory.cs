using TestTask.Core;
using TestTask.SphereNS;
using UnityEngine;

namespace TestTask.Factories
{
    [CreateAssetMenu(menuName = "Factories/SphereFactory", order = 51)]
    public class SphereFactory : GameObjectFactory
    {
        [SerializeField]
        private Sphere _prefab;
        [SerializeField]
        private SphereConfig _config;

        public Sphere Create()
        {
            Sphere sphere = CreateObjectInFactoryScene(_prefab);

            float velocityUnmodified = _config.Velocity;
            float velocityWithBonus = velocityUnmodified + Difficulty.VelocityBonus;
            float velocity = velocityWithBonus < Difficulty.MaxVelocity ? velocityWithBonus : Difficulty.MaxVelocity;

            SphereData data = new SphereData(velocity, _config.Color, 
                _config.RewardPoints, _config.Damage);
            sphere.Initialize(data);

            return sphere;
        }
    }
}
