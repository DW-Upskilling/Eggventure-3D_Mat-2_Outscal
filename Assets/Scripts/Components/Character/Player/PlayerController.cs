using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Managers;
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

        public override void SetSpawner(SpawnManager spawnManager)
        {
            Transform spawnerTransform = spawnManager.gameObject.transform;

            characterView.transform.SetPositionAndRotation(spawnerTransform.position, spawnerTransform.rotation);
            characterView.transform.SetParent(spawnerTransform);
        }

        public void HandleUserInput()
        {
            UserInputHandler userInputHandler = characterModel.UserInputHandler;

            movementHorizontal = userInputHandler.horizontal;
            movementVertical = userInputHandler.vertical;

            movementSprint = userInputHandler.sprint;

            Move();

            rotationHorizontal = userInputHandler.mouseY;
            rotationVertical = userInputHandler.mouseX;

            HandleRotation();
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

        protected override void HandleRotation()
        {
            base.HandleRotation();

            Camera mainCamera = characterModel.CameraContainerTransform.gameObject.GetComponentInChildren<Camera>();
            Transform characterDirectionTransform = characterView.CharacterDirectionTransform;

            if (mainCamera != null && characterDirectionTransform != null)
                mainCamera.transform.rotation = characterDirectionTransform.rotation;
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
