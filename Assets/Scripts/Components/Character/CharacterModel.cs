using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    public class CharacterModel<T> : Model
        where T: CharacterScriptableObject
    {
        public T CharacterScriptableObject { get; private set; }

        public float Health { get; set; }
        public float Energy { get; set; }
        
        public float HealthRegeneration { get; set; }
        public float EnergyRegeneration { get; set; }

        public float xRotation { get; set; }
        public float yRotation { get; set; }

        public CharacterModel(T characterScriptableObject)
        {
            CharacterScriptableObject = characterScriptableObject;

            Health = characterScriptableObject.Health;
            Energy = characterScriptableObject.Energy;

            HealthRegeneration = characterScriptableObject.HealthRegeneration;
            EnergyRegeneration = characterScriptableObject.EnergyRegeneration;
        }
    }
}
