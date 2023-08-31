using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Managers;
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

        protected float movementHorizontal { get; set; }
        protected float movementVertical { get; set; }
        protected float movementSprint { get; set; }

        protected float rotationHorizontal { get; set; }
        protected float rotationVertical { get; set; }

        public CharacterController(T characterScriptableObject)
        {
            characterModel = CreateCharacterModel(characterScriptableObject);
            characterView = InstantiateCharacterView(characterScriptableObject);
        }

        protected virtual void HandleMovement()
        {
            Transform characterDirectionTransform = characterView.CharacterDirectionTransform;

            float speedMultiplier = 1f;
            if (movementSprint != 0)
                speedMultiplier += .5f;

            Vector3 moveForwardDirection = characterDirectionTransform.forward * movementVertical * speedMultiplier;
            Vector3 moveRightDirection = characterDirectionTransform.right * movementHorizontal * speedMultiplier;

            Vector3 moveDirection = moveForwardDirection + moveRightDirection;

            characterView.Force = moveDirection.normalized * characterModel.CharacterScriptableObject.MovementSpeed;
            characterView.ForceMode = ForceMode.Force;
            characterView.useRigidBody = true;
        }

        protected virtual void HandleMovementSpeed()
        {
            Vector3 currentVelocity = characterView.Velocity;
            Vector3 flatVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

            float maxSpeed = characterModel.CharacterScriptableObject.MovementSpeed;
            if(movementSprint != 0)
                maxSpeed += maxSpeed * 0.5f;

            if (flatVelocity.magnitude > maxSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * characterModel.CharacterScriptableObject.MovementSpeed;
                characterView.Velocity = new Vector3(limitedVelocity.x, currentVelocity.y, limitedVelocity.z);
            }
        }

        protected virtual void HandleRotation()
        {
            characterModel.xRotation -= rotationHorizontal * characterModel.CharacterScriptableObject.XAxisSenstivity;
            characterModel.xRotation = Mathf.Clamp(characterModel.xRotation, -90f, 90f);
            characterModel.yRotation += rotationVertical * characterModel.CharacterScriptableObject.YAxisSenstivity;

            Transform characterDirectionTransform = characterView.CharacterDirectionTransform;
            if (characterDirectionTransform != null)
                characterDirectionTransform.rotation = Quaternion.Euler(characterModel.xRotation, characterModel.yRotation, 0);
        }

        public abstract void Start();
        public abstract void SetActive(bool state);
        public abstract void SetSpawner(SpawnManager spawnManager);

        protected abstract V CreateCharacterModel(T characterScriptableObject);
        protected abstract U InstantiateCharacterView(T characterScriptableObject);
    }
}
