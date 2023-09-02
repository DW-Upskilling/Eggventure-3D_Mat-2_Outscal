using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy.EnemyBehaviour
{
    public class EnemyAttackBehaviour : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            Debug.Log("EnemyAttackBehaviour");
        }
    }
}
