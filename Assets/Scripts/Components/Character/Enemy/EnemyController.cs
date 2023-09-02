using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;


namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyController : CharacterController<EnemyScriptableObject, EnemyView, EnemyModel>
    {

        public EnemyController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            characterView.SetController(this);
        }
        public void SetRandomMovement()
        {
            movementHorizontal = UnityEngine.Random.Range(-1, 1);
            movementVertical = UnityEngine.Random.Range(-1, 1);
            movementSprint = UnityEngine.Random.Range(-1, 1);
        }

        public override void SetSpawner(SpawnManager spawnManager)
        {
            Transform spawnerTransform = spawnManager.gameObject.transform;

            characterView.transform.SetPositionAndRotation(spawnerTransform.position, spawnerTransform.rotation);
            characterView.transform.SetParent(spawnerTransform);
        }

        public override void Start()
        {
            SetActive(true);
        }

        public override void SetActive(bool state)
        {
            characterView.gameObject.SetActive(state);
        }

        protected override void HandleRotation()
        {
            
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
