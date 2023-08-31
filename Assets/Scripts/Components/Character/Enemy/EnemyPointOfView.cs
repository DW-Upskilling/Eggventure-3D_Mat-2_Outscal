using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;
using Outscal.UnityAdvanced.Mat2.Components.Character.Player;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyPointOfView : MonoBehaviour
    {
        [SerializeField]
        private Animator stateMachine;

        [SerializeField]
        private EnemyRadar enemyRadar;

        private int attackId;
        private float cooldown;

        private void Awake()
        {
            attackId = Animator.StringToHash("Attack");
            cooldown = Constants.DefaultStateCooldown;
        }

        private void Update()
        {
            cooldown -= Time.deltaTime;
        }

        private void OnTriggerStay(Collider collider)
        {
            PlayerView playerView = collider.gameObject.GetComponent<PlayerView>();
            if(playerView != null && cooldown <= 0)
            {
                stateMachine.SetTrigger(attackId);
                cooldown = Constants.DefaultStateCooldown;
            }
        }
    }
}
