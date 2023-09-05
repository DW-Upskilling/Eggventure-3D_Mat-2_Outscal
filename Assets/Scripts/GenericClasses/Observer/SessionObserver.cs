using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Observer
{
    // SessionObsever is used when required when observer required for entire session
    // Example: Achievement System
    public abstract class SessionObserver<S, T> : SessionSingleton<S>
        where S : SessionObserver<S, T>
    {
        private static event Action<T> ObserverQueue;

        public void AddListener(Action<T> listener)
        {
            ObserverQueue += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            ObserverQueue -= listener;
        }

        protected void TriggerEvent(T t)
        {
            ObserverQueue?.Invoke(t);
        }
    }
}
