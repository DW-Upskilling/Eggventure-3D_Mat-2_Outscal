using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Character/Player")]
    public class PlayerScriptableObject : CharacterScriptableObject
    {
        [SerializeField]
        private PlayerView playerPrefab;
        public PlayerView PlayerPrefab { get { return playerPrefab; } }

        [SerializeField]
        private PlayerCameraModes playerCameraMode;
        public PlayerCameraModes PlayerCameraMode { get { return playerCameraMode; } }
    }
}
