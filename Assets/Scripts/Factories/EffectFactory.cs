using TestTask.Utility;
using UnityEngine;

namespace TestTask.Factories
{
    [CreateAssetMenu (menuName = "Factories/EffectFactory", order = 51)]
    public class EffectFactory : GameObjectFactory
    {
        [SerializeField]
        private ParticleEffect _prefab;

        public ParticleEffect Create()
        {
            ParticleEffect effect = CreateObjectInFactoryScene(_prefab);
            return effect;
        }
    }
}
