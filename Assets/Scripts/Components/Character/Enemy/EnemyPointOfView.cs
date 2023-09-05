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

        [SerializeField]
        private Transform muzzlePointTransform;

        private int attackId;
        private float cooldown;

        private void Awake()
        {
            attackId = Animator.StringToHash("Attack");
        }

        private void OnEnable()
        {
            cooldown = Constants.DefaultStateCooldown;
        }

        private void Update()
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0)
            {
                Ray ray = new Ray(muzzlePointTransform.position, muzzlePointTransform.forward);
                bool cast = Physics.Raycast(ray, out RaycastHit hit, enemyRadar.DistanceInBetween);

                if (cast)
                    stateMachine.SetTrigger(attackId);

                cooldown = Constants.DefaultStateCooldown;
            }
        }
    }
}
