using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.Observer;

namespace Outscal.UnityAdvanced.Mat2.Events
{
    public class EnergyUsageEventHandler : SceneObserver<EnergyUsageEventHandler, CharacterView>
    {
        public int TotalEnergyUses { get; private set; }

        protected override void Initialize()
        {
            TotalEnergyUses = 0;
        }

        public void TriggerEnergyUsagesEvent(CharacterView view)
        {
            TotalEnergyUses++;
            base.TriggerEvent(view);
        }
    }
}
