using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class Observer<T> : Singleton<Observer<T>> where T : Observer<T>
    {
        
    }
}
