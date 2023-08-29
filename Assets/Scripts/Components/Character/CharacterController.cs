using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    public abstract class CharacterController<T, U, V> : Controller
        where T: CharacterScriptableObject
        where U : CharacterView
        where V: CharacterModel<T>
    {
        protected V characterModel;
        protected U characterView;

        public CharacterController(T characterScriptableObject)
        {
            characterModel = CreateCharacterModel(characterScriptableObject);
            characterView = InstantiateCharacterView(characterScriptableObject);
        }

        public abstract void Start();
        public abstract void SetActive(bool state);

        protected abstract V CreateCharacterModel(T characterScriptableObject);
        protected abstract U InstantiateCharacterView(T characterScriptableObject);
    }
}
