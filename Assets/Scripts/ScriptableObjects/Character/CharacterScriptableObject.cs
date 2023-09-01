using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;
using Outscal.UnityAdvanced.Mat2.Components.Character;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character
{
    public class CharacterScriptableObject : ScriptableObject
    {
        [SerializeField]
        private CharacterTypes characterType;
        public CharacterTypes CharacterType { get { return characterType; } }

        [SerializeField]
        private float health = Constants.DefaultHealth;
        public float Health { get { return health; } }

        [SerializeField]
        private float energy = Constants.DefaultEnergy;
        public float Energy { get { return energy; } }

        [SerializeField]
        private float healthRegeneration = Constants.DefaultHealthRegeneration;
        public float HealthRegeneration { get { return healthRegeneration; } }

        [SerializeField]
        private float energyRegeneration = Constants.DefaultEnergyRegeneration;
        public float EnergyRegeneration { get { return energyRegeneration; } }

        [SerializeField, Range(0, 12f)]
        private float xAxisSenstivity = Constants.DefaultXAxisSenstivity;
        public float XAxisSenstivity { get { return xAxisSenstivity; } }

        [SerializeField, Range(0f, 12f)]
        private float yAxisSenstivity = Constants.DefaultYAxisSenstivity;
        public float YAxisSenstivity { get { return yAxisSenstivity; } }

        [SerializeField, Range(0f, 12f)]
        private float movementSpeed = Constants.DefaultMovementSpeed;
        public float MovementSpeed { get { return movementSpeed; } }
    }
}
