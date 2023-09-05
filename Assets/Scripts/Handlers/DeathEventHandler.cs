using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.Observer;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class DeathEventHandler : SceneObserver<CharacterController>
    {
        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public override void TriggerEvent(CharacterController characterController)
        {
            base.TriggerEvent(characterController);
        }
    }
}
