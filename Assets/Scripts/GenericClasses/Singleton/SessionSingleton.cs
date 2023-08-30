using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton
{
    // SessionSingleton is used when you wanted a object stay entirety of the gamesession
    public abstract class SessionSingleton<T> : MonoBehaviour where T : SessionSingleton<T>
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
