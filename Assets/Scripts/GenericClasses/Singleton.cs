using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
                this.Initialize();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        // method to make use of Awake functionality by derived classes
        protected abstract void Initialize();
    }
}
