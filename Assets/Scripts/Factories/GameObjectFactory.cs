using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask.Factories
{
    public abstract class GameObjectFactory : ScriptableObject
    {
        [SerializeField]
        private string _sceneName;

        protected Scene _scene;

        protected T CreateObjectInFactoryScene<T>(T prefab) where T : MonoBehaviour
        {
            if (_scene.isLoaded == false)
            {
                _scene = SceneManager.CreateScene(_sceneName);
            }

            T instance = Instantiate(prefab);
            SceneManager.MoveGameObjectToScene(instance.gameObject, _scene);

            return instance;
        }

        public async void UnloadScene()
        {
            if (_scene.isLoaded)
            {
                AsyncOperation op = SceneManager.UnloadSceneAsync(_scene);
                while (op.isDone == false)
                {
                    await Task.Delay(1);
                }
            }
        }

        public void Recycle<T>(T obj) where T : MonoBehaviour
        {
            Destroy(obj.gameObject);
        }
    }
}