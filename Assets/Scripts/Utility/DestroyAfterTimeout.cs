using System.Collections;
using UnityEngine;

namespace TestTask.Utility
{
    public abstract class DestroyAfterTimeout : MonoBehaviour
    {
        [SerializeField]
        private int _aliveTime;
        private void Start()
        {
            StartCoroutine(DeathTimer());
        }

        private IEnumerator DeathTimer()
        {
            yield return new WaitForSeconds(_aliveTime);
            Destroy(gameObject);
        }
    }
}
