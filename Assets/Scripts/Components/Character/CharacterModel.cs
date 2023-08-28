using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    public class CharacterModel<T, S> : Model<CharacterModel<T, S>> 
        where T: CharacterView
        where S: CharacterScriptableObject<T>
    {
        public S CharacterScriptableObject { get; private set; }

        public CharacterModel(S characterScriptableObject)
        {
            this.CharacterScriptableObject = characterScriptableObject;
        }
    }
}
