using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Observer
{
    // SessionObsever is used when required when observer required for entire session
    // Example: Achievement System
    public abstract class SessionObserver<T> : SessionSingleton<SessionObserver<T>> where T : SessionObserver<T>
    {
        
    }
}
