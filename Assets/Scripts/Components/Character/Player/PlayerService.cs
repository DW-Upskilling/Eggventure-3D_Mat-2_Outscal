using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Components.Spawn;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerService : Service<PlayerService>
    {
        [SerializeField]
        private Transform cameraContainerTransform;

        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;

        [SerializeField]
        private Slider healthBar;
        [SerializeField]
        private Slider energyBar;

        [SerializeField]
        private List<SpawnController> spawnManagers;

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
            playerController.HealthBar = healthBar;
            playerController.EnergyBar = energyBar;

            playerController.SetActive(true);
        }

        private void Update()
        {
            userInputHandler.Update();
        }

        private SpawnController GetRandomSpawnManager()
        {
            List<SpawnController> availableSpawners = spawnManagers.FindAll(e => e.IsOccupied == false);
            if (availableSpawners.Count < 1)
                return null;

            int index = Mathf.RoundToInt(Random.Range(1f, availableSpawners.Count));
            return availableSpawners[index - 1];
        }
    }
}
