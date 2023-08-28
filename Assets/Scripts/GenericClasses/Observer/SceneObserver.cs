using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Observer
{
    // SceneObserver is used when required on GameObjects that get destroyed once scene changes
    public abstract class SceneObserver<T> : SceneSingleton<SceneObserver<T>> where T : SceneObserver<T>
    {
        
    }
}
