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

        public float xRotation { get; set; }
        public float yRotation { get; set; }

        public PlayerModel(PlayerScriptableObject playerScriptableObject): base(playerScriptableObject)
        {
            PlayerCameraMode = playerScriptableObject.PlayerCameraMode;
        }
    }
}
