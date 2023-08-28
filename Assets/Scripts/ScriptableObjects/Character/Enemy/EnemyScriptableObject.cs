using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.Components.Character;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Character/Enemy/New")]
    public class EnemyScriptableObject : CharacterScriptableObject<CharacterView>
    {
        [SerializeField]
        private EnemyCharacterTypes enemyCharacterTypes;
        public EnemyCharacterTypes EnemyCharacterTypes { get { return enemyCharacterTypes; } }

        [SerializeField]
        private EnemyModes enemyModes;
        public EnemyModes EnemyModes { get { return enemyModes; } }

    }
}
