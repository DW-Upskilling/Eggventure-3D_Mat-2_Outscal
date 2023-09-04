using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyController : CharacterController<EnemyScriptableObject, EnemyView, EnemyModel>
    {
        Transform characterDirectionTransform;
        EnemiesPoolHandler enemiesPoolHandler;

        public EnemyController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            characterView.SetController(this);
            characterDirectionTransform = characterView.CharacterDirectionTransform;
        }
        public void SetRandomMovement()
        {
            movementHorizontal = UnityEngine.Random.Range(-1, 1);
            movementVertical = UnityEngine.Random.Range(-1, 1);
            movementSprint = UnityEngine.Random.Range(-1, 1);
        }

        public void SetRandomRotation()
        {
            rotationHorizontal = UnityEngine.Random.Range(-1f, 1f);
            rotationVertical = UnityEngine.Random.Range(-1f, 1f);
        }

        public void SetMovement(Vector3 moveDirection)
        {
            SetRandomMovement();
            movementVertical = Mathf.Clamp(Vector3.Dot(moveDirection, characterDirectionTransform.forward), -1f, 1f);
            movementHorizontal = Mathf.Clamp(Vector3.Dot(moveDirection, characterDirectionTransform.right), -1f, 1f);
        }

        public void SetRotation(Vector3 moveDirection)
        {
            SetRandomRotation();

            rotationHorizontal = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            rotationVertical = Mathf.Atan2(moveDirection.y, moveDirection.magnitude) * Mathf.Rad2Deg;
        }

        public override void SetSpawner(SpawnManager spawnManager)
        {
            Transform spawnerTransform = spawnManager.gameObject.transform;

            characterView.transform.SetPositionAndRotation(spawnerTransform.position, spawnerTransform.rotation);
            characterView.transform.SetParent(spawnerTransform);
        }

        public void Attack()
        {
            ActivateLaser();
        }

        public void HoldAttack()
        {
            DeactivateLaser();
        }

        public void SetEnemiesPoolHandler(EnemiesPoolHandler enemiesPoolHandler)
        {
            this.enemiesPoolHandler = enemiesPoolHandler;
        }

        public override void Start()
        {
            SetActive(true);
        }

        public override void SetActive(bool state)
        {
            characterView.gameObject.SetActive(state);
        }

        public override void HandleRotation()
        {
            base.HandleRotation();

            EnemyPointOfView EnemyPointOfView = characterView.EnemyPointOfView;
            EnemyRadar EnemyRadar = characterView.EnemyRadar;

            Transform characterDirectionTransform = characterView.CharacterDirectionTransform;

            if (characterDirectionTransform != null) {
                if (EnemyPointOfView != null)
                    EnemyPointOfView.transform.rotation = characterDirectionTransform.rotation;
                if (EnemyRadar != null)
                    EnemyRadar.transform.rotation = characterDirectionTransform.rotation;
            }
        }

        protected override void Destroy() {
            enemiesPoolHandler.ReturnItem(this);
        }

        protected override EnemyModel CreateCharacterModel(EnemyScriptableObject enemyScriptableObject)
        {
            return new EnemyModel(enemyScriptableObject);
        }
        protected override EnemyView InstantiateCharacterView(EnemyScriptableObject enemyScriptableObject)
        {
            return GameObject.Instantiate<EnemyView>(enemyScriptableObject.EnemyPrefab);
        }
    }
}
