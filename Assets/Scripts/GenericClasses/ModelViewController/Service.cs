using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController
{
    public abstract class Service<T> : SceneSingleton<Service<T>> where T : Service<T> {
        protected abstract void Start();
    }
}
