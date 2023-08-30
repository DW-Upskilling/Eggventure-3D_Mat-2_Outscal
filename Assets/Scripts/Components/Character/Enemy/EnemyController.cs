using System;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyController : CharacterController<EnemyScriptableObject, EnemyView, EnemyModel>
    {
        Transform spawn;

        public EnemyController(EnemyScriptableObject enemyScriptableObject, Transform spawn) : base(enemyScriptableObject)
        {
            characterView.transform.SetPositionAndRotation(spawn.position, spawn.rotation);
            characterView.transform.SetParent(spawn);
            characterView.SetController(this);
        }

        public override void Start()
        {
            SetActive(true);
        }

        public override void SetActive(bool state)
        {
            characterView.gameObject.SetActive(state);
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
