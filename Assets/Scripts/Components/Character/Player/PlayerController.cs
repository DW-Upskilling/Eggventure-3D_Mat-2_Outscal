using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerController : CharacterController<PlayerView, PlayerScriptableObject, CharacterModel<PlayerView, PlayerScriptableObject>>
    {
        public PlayerController(PlayerScriptableObject playerScriptableObject) : base(playerScriptableObject)
        {
            
        }

        protected override CharacterModel<PlayerView, PlayerScriptableObject> CreateCharacterModel(PlayerScriptableObject playerScriptableObject)
        {
            return new CharacterModel<PlayerView, PlayerScriptableObject>(playerScriptableObject);
        }
        protected override PlayerView InstantiateCharacterView(PlayerView playerPrefab)
        {
            return GameObject.Instantiate<PlayerView>(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
