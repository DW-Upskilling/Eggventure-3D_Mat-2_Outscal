using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.Observer;

namespace Outscal.UnityAdvanced.Mat2.Events
{
    public class KillEventHandler : SceneObserver<KillEventHandler, CharacterView>
    {
        public int TotalKills { get; private set; }

        protected override void Initialize()
        {
            TotalKills = 0;
        }

        public void TriggerKillEvent(CharacterView view)
        {
            TotalKills++;
            base.TriggerEvent(view);
        }
    }
}
