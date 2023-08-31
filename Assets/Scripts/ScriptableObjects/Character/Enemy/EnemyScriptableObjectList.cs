using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/Character/Enemy/List")]
    public class EnemyScriptableObjectList : ScriptableObjectList<EnemyScriptableObject>
    {
        [SerializeField]
        private EnemyCharacterTypes enemyCharacterType;
        public EnemyCharacterTypes EnemyCharacterType { get { return enemyCharacterType; } }
    }
}
