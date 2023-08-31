using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy.EnemyBehaviour
{
    public class EnemyIdleBehaviour : StateMachineBehaviour
    {
        private float timeInterval;

        private int patrolId;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            timeInterval = Random.Range(Constants.DefaultMinStateCooldown, Constants.DefaultMaxStateCooldown);
            patrolId = Animator.StringToHash("Patrol");
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            timeInterval -= Time.deltaTime;
            if (timeInterval <= 0)
            {
                animator.SetBool(patrolId, true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
