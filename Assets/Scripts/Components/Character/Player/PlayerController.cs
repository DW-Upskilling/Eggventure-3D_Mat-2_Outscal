using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerController : CharacterController<PlayerScriptableObject, PlayerView, PlayerModel>
    {
        public PlayerController(PlayerScriptableObject playerScriptableObject) : base(playerScriptableObject)
        {
            characterView.SetController(this);
        }

        public override void Start()
        {
            SetActive(true);
        }

        public override void SetActive(bool state)
        {
            characterView.gameObject.SetActive(state);
        }

        public void HandleUserInput()
        {
            handleMovement();
            handleRotation();
        }

        public void UpdateCameraPosition()
        {
            switch (characterModel.PlayerCameraMode)
            {
                case PlayerCameraModes.FirstPerson:
                    characterModel.CameraContainerTransform.position = characterView.FirstPersonModeCameraTransform.position;
                    break;
                case PlayerCameraModes.ThirdPerson:
                    characterModel.CameraContainerTransform.position = characterView.ThirdPersonModeCameraTransform.position;
                    break;
            }
        }

        public Transform CameraContainerTransform { set { characterModel.CameraContainerTransform = value; } }
        public UserInputHandler UserInputHandler { set { characterModel.UserInputHandler = value; } }

        protected override PlayerModel CreateCharacterModel(PlayerScriptableObject playerScriptableObject)
        {
            return new PlayerModel(playerScriptableObject);
        }
        protected override PlayerView InstantiateCharacterView(PlayerScriptableObject playerScriptableObject)
        {
            return GameObject.Instantiate<PlayerView>(playerScriptableObject.PlayerPrefab, Vector3.zero, Quaternion.identity);
        }

        public Transform GetCameraTransform()
        {
            switch (characterModel.PlayerCameraMode)
            {
                case PlayerCameraModes.FirstPerson:
                    return characterView.FirstPersonModeCameraTransform;
                case PlayerCameraModes.ThirdPerson:
                    return characterView.ThirdPersonModeCameraTransform;
            }
            return null;
        }

        private void handleMovement()
        {
            UserInputHandler userInputHandler = characterModel.UserInputHandler;
            Transform playerDirectionTransform = characterView.PlayerDirectionTransform;

            Vector3 moveDirection = playerDirectionTransform.forward * userInputHandler.vertical + playerDirectionTransform.right * userInputHandler.horizontal;

            characterView.Force = moveDirection.normalized * characterModel.CharacterScriptableObject.MovementSpeed;
            characterView.ForceMode = ForceMode.Force;
            characterView.useRigidBody = true;
        }

        private void handleRotation()
        {
            UserInputHandler userInputHandler = characterModel.UserInputHandler;

            characterModel.xRotation -= userInputHandler.mouseY * Time.deltaTime * characterModel.PlayerXSenstivity * characterModel.CharacterScriptableObject.XAxisSenstivity;
            characterModel.xRotation = Mathf.Clamp(characterModel.xRotation, -90f, 90f);
            characterModel.yRotation += userInputHandler.mouseX * Time.deltaTime * characterModel.PlayerYSenstivity * characterModel.CharacterScriptableObject.YAxisSenstivity;

            Camera mainCamera = characterModel.CameraContainerTransform.gameObject.GetComponentInChildren<Camera>();
            if (mainCamera != null)
                mainCamera.transform.rotation = Quaternion.Euler(characterModel.xRotation, characterModel.yRotation, 0);

            Transform playerDirectionTransform = characterView.PlayerDirectionTransform;
            if (playerDirectionTransform != null)
                playerDirectionTransform.rotation = Quaternion.Euler(0, characterModel.yRotation, 0);
        }

        private void switchCameraView()
        {
            switch (characterModel.PlayerCameraMode)
            {
                case PlayerCameraModes.FirstPerson:
                    break;
                case PlayerCameraModes.ThirdPerson:
                    break;
            }
        }
    }
}
