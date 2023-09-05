using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Utils;
using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyRadar : MonoBehaviour
    {
        [SerializeField]
        private Animator stateMachine;

        [SerializeField]
        private EnemyPointOfView enemyPointOfView;

        public GameObject ColliderGameObject { get; set; }
        public float DistanceInBetween { get; private set; }

        private EnemyController enemyController;

        private int chaseId;
        private float cooldown;

        private void Awake()
        {
            if (enemyPointOfView == null)
                throw new UnassignedReferenceException("Assign enemyPointOfView gameObject");

            chaseId = Animator.StringToHash("Chase");
            cooldown = Constants.DefaultStateCooldown;
        }

        private void Start()
        {
            enemyController = gameObject.GetComponentInParent<EnemyView>().GetEnemyController();
        }

        private void Update()
        {
            cooldown -= Time.deltaTime;
        }

        private void OnTriggerStay(Collider collider)
        {
            Damageable damageable = collider.gameObject.GetComponent<Damageable>();
            if(damageable != null && cooldown <= 0 && enemyController.CanChase)
            {
                ColliderGameObject = collider.gameObject;

                stateMachine.SetTrigger(chaseId);
                enemyPointOfView.gameObject.SetActive(true);

                DistanceInBetween = Vector3.Distance(transform.position, ColliderGameObject.transform.position);

                cooldown = Constants.DefaultStateCooldown;
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.Equals(ColliderGameObject))
            {
                enemyPointOfView.gameObject.SetActive(false);

                DistanceInBetween = -1;
                
                cooldown = Constants.DefaultStateCooldown;
            }
        }
    }
}
