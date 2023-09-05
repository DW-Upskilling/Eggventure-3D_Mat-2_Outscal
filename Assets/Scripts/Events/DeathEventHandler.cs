using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.Observer;

namespace Outscal.UnityAdvanced.Mat2.Events
{
    public class DeathEventHandler : SceneObserver<DeathEventHandler, CharacterView>
    {
        public int TotalDeaths { get; private set; }

        protected override void Initialize()
        {
            TotalDeaths = 0;
        }

        public void TriggerDeathEvent(CharacterView view)
        {
            TotalDeaths++;
            base.TriggerEvent(view);
        }
    }
}
