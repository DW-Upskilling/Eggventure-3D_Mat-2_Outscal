using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerService : Service<PlayerService>
    {
        [SerializeField]
        private Transform cameraPosition;

        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;

        PlayerController playerController;

        protected override void Initialize()
        {
            playerController = new PlayerController(playerScriptableObject);
        }

        protected override void Start()
        {
            
        }
    }
}
