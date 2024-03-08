using UnityEngine;
using UnityEngine.Events;

namespace Tank1990
{
    public class BaseScript : MonoBehaviour
    {
        public UnityEvent OnDeath;

        private void OnDisable()
        {
            OnDeath.RemoveAllListeners();
        }
    }
}
