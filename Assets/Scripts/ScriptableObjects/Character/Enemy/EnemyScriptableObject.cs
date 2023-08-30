using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Character/Enemy/New")]
    public class EnemyScriptableObject : CharacterScriptableObject
    {
        [SerializeField]
        private EnemyCharacterTypes enemyCharacterType;
        public EnemyCharacterTypes EnemyCharacterType { get { return enemyCharacterType; } }

        [SerializeField]
        private EnemyModes enemyMode;
        public EnemyModes EnemyMode { get { return enemyMode; } }

        [SerializeField]
        private EnemyView enemyPrefab;
        public EnemyView EnemyPrefab { get { return enemyPrefab; } }

    }
}
