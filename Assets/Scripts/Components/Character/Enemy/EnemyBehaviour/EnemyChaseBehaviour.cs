using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy.EnemyBehaviour
{
    public class EnemyChaseBehaviour : StateMachineBehaviour
    {
        private GameObject trackingGameObject;

        private EnemyController enemyController;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            enemyController = animator.gameObject.GetComponent<EnemyView>().GetEnemyController();

            EnemyRadar enemyRadar = animator.gameObject.GetComponentInChildren<EnemyRadar>();
            if(enemyRadar != null)
                trackingGameObject = enemyRadar.ColliderGameObject;
            
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            
            Vector3 moveDirection = (trackingGameObject.transform.position - animator.transform.position).normalized;
            enemyController.SetMovement(moveDirection);
            enemyController.SetRotation(moveDirection);

            enemyController.HandleRotation();

            enemyController.Move();
        }
    }
}
