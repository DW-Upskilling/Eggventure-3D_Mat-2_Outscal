using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character
{
    public class CharacterScriptableObject : ScriptableObject
    {
        [SerializeField]
        private CharacterTypes characterType;
        public CharacterTypes CharacterTypes { get { return characterType; } }
    }
}
