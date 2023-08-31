using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton
{
    // SceneSingleton to be destroyed if the scene changes
    // Examples: Player/Enemy Spawner
    public abstract class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
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
