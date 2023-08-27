using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy
{
    [CreateAssetMenu(fileName = "EnemyBossScriptableObjectList", menuName = "ScriptableObjects/Character/Enemy/Boss/List")]
    public class EnemyBossScriptableObjectList : ScriptableObjectList<EnemyBossScriptableObject>
    {
    }
}
