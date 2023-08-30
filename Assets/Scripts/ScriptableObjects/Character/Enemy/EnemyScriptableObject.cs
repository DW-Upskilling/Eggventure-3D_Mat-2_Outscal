using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.Components.Character;

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

    }
}
