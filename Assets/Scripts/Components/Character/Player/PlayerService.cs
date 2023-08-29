using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Handlers;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerService : Service<PlayerService>
    {
        [SerializeField]
        private Transform cameraContainerTransform;

        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;

        PlayerController playerController;
        UserInputHandler userInputHandler;

        protected override void Initialize()
        {
            playerController = new PlayerController(playerScriptableObject);

            userInputHandler = new UserInputHandler();

            playerController.CameraContainerTransform = cameraContainerTransform;
            playerController.UserInputHandler = userInputHandler;
        }

        protected override void Start()
        {
            playerController.SetActive(true);
        }

        private void Update()
        {
            userInputHandler.Update();
        }
    }
}
