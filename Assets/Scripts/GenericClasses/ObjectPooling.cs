using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ObjectPooling<T> : SceneSingleton<ObjectPooling<T>> where T : ObjectPooling<T>
    {

    }
}
