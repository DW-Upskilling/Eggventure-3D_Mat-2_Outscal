using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyModel : CharacterModel<EnemyScriptableObject> 
    {

        public EnemyModel(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            
        }
    }
}
