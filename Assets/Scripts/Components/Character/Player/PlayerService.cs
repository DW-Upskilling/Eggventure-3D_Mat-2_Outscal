using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Managers;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerService : Service<PlayerService>
    {
        [SerializeField]
        private Transform cameraContainerTransform;

        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;

        [SerializeField]
        private List<SpawnManager> spawnManagers;

        PlayerController playerController;
        UserInputHandler userInputHandler;

        protected override void Initialize()
        {
            if (spawnManagers == null || spawnManagers.Count == 0)
                throw new UnassignedReferenceException("No spawners found");

            playerController = new PlayerController(playerScriptableObject);

            userInputHandler = new UserInputHandler();

            playerController.CameraContainerTransform = cameraContainerTransform;
            playerController.UserInputHandler = userInputHandler;
            playerController.SetSpawner(GetRandomSpawnManager());
        }

        protected override void Start()
        {
            playerController.SetActive(true);
        }

        private void Update()
        {
            userInputHandler.Update();
        }

        private SpawnManager GetRandomSpawnManager()
        {
            List<SpawnManager> availableSpawners = spawnManagers.FindAll(e => e.IsOccupied == false);
            if (availableSpawners.Count < 1)
                return null;

            int index = Mathf.RoundToInt(Random.Range(1f, availableSpawners.Count));
            return availableSpawners[index - 1];
        }
    }
}
