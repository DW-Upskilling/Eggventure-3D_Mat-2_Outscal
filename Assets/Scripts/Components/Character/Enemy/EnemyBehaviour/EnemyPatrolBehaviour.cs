using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy.EnemyBehaviour
{
    public class EnemyPatrolBehaviour : StateMachineBehaviour
    {
        private EnemyController enemyController;

        private float timeInterval;

        private int patrolId;

        private float movementInterval;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            enemyController = animator.gameObject.GetComponent<EnemyView>().GetEnemyController();
            movementInterval = Random.Range(Constants.DefaultMinStateCooldown, Constants.DefaultMaxStateCooldown);

            timeInterval = Random.Range(Constants.DefaultMinStateCooldown, Constants.DefaultMaxStateCooldown);
            patrolId = Animator.StringToHash("Patrol");
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            
            movementInterval -= Time.deltaTime;

            if (movementInterval <= 0)
            {
                enemyController.SetRandomMovement();
                enemyController.SetRandomRotation();
                movementInterval = Random.Range(Constants.DefaultMinStateCooldown, Constants.DefaultMaxStateCooldown);
            }

            enemyController.Move();
            enemyController.HandleRotation();

            timeInterval -= Time.deltaTime;
            if (timeInterval <= 0)
            {
                animator.SetBool(patrolId, false);
            }
        }

    }
}
