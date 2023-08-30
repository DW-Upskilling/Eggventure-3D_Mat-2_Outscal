using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerModel : CharacterModel<PlayerScriptableObject> 
    {
        public PlayerCameraModes PlayerCameraMode { get; set; }
        public Transform CameraContainerTransform { get; set; }
        public UserInputHandler UserInputHandler { get; set; }

        public float PlayerXSenstivity { get; set; }
        public float PlayerYSenstivity { get; set; }

        public float xRotation { get; set; }
        public float yRotation { get; set; }

        public PlayerModel(PlayerScriptableObject playerScriptableObject): base(playerScriptableObject)
        {
            PlayerCameraMode = playerScriptableObject.PlayerCameraMode;

            // Can be later enchanced to updated from playerprefs
            // This is one of the options user can customise in settings
            PlayerXSenstivity = 1f;
            PlayerYSenstivity = 1f;
        }
    }
}
