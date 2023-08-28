using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    public abstract class CharacterController<T, S, V> : Controller<CharacterController<T, S, V>>
        where T : CharacterView
        where S : CharacterScriptableObject<T>
        where V : CharacterModel<T, S>
    {
        private S characterScriptableObject;
        private V characterModel;
        private T characterView;

        public CharacterController(S characterScriptableObject)
        {
            this.characterScriptableObject = characterScriptableObject;

            characterModel = CreateCharacterModel(characterScriptableObject);
            characterView = InstantiateCharacterView(characterScriptableObject.Prefab);
        }

        protected abstract V CreateCharacterModel(S characterScriptableObject);
        protected abstract T InstantiateCharacterView(T characterPrefab);

    }
}
