using System.Linq;
using System.Collections.Generic;
using TestTask.Factories;

namespace TestTask.SphereNS
{
    public class SphereStorage
    {
        private List<Sphere> _spheres;

        public SphereStorage()
        {
            _spheres = new List<Sphere>();
        }

        public Sphere[] GetSpheresBelowScreen(float BelowScreenY)
        {
            return _spheres.Where(x => x.Y < BelowScreenY).ToArray();
        }

        public void AddSphere(Sphere sphere)
        {
            _spheres.Add(sphere);
        }

        public void RemoveSphere(Sphere sphere)
        {
            _spheres.Remove(sphere);
        }

        public void Clear(SphereFactory factory)
        {
            _spheres.ForEach(s => factory.Recycle(s));
            _spheres.Clear();
        }
    }
}
