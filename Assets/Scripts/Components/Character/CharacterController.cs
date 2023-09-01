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

        public float MovementSpeed { get { return characterModel.CharacterScriptableObject.MovementSpeed; } }

        public CharacterController(T characterScriptableObject)
        {
            characterModel = CreateCharacterModel(characterScriptableObject);
            characterView = InstantiateCharacterView(characterScriptableObject);
        }

        public virtual void Move()
        {
            Transform characterDirectionTransform = characterView.CharacterDirectionTransform;

            Vector3 moveForwardDirection = characterDirectionTransform.forward * movementVertical;
            Vector3 moveRightDirection = characterDirectionTransform.right * movementHorizontal;

            Vector3 moveDirection = moveForwardDirection + moveRightDirection;

            HandleMovement(moveDirection);
            HandleMovementSpeed();
        }

        public virtual void Move(Vector3 moveDirection)
        {
            HandleMovement(moveDirection);
            HandleMovementSpeed();
        }

        private void HandleMovement(Vector3 moveDirection)
        {
            float speedMultiplier = 1f;
            if (movementSprint != 0)
                speedMultiplier += .5f;

            moveDirection *= speedMultiplier;
            moveDirection.y = 0f;

            characterView.Force = moveDirection.normalized * MovementSpeed;
            characterView.ForceMode = ForceMode.Force;
            characterView.useRigidBody = true;
        }

        private void HandleMovementSpeed()
        {
            Vector3 currentVelocity = characterView.Velocity;
            Vector3 flatVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

            float maxSpeed = MovementSpeed;
            if(movementSprint != 0)
                maxSpeed += maxSpeed * 0.5f;

            if (flatVelocity.magnitude > maxSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * MovementSpeed;
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
