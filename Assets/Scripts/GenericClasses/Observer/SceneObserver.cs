using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.Observer
{
    // SceneObserver is used when required on GameObjects that get destroyed once scene changes
    public abstract class SceneObserver<T> : SceneSingleton<SceneObserver<T>>
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
