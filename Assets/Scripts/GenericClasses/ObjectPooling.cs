using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ObjectPooling<T> : Singleton<ObjectPooling<T>> where T : ObjectPooling<T>
    {
        
    }
}
