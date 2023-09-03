using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class EnemiesPoolHandler : ObjectPooling<EnemyController>
    {
        private EnemiesToSpawn enemiesToSpawn;
        private EnemiesToKill enemiesToKill;
        public EnemiesPoolHandler(EnemiesToSpawn enemiesToSpawn, EnemiesToKill enemiesToKill) : base()
        {
            this.enemiesToSpawn = enemiesToSpawn;
            this.enemiesToKill = enemiesToKill;
        }

        public EnemyCharacterTypes GetEnemyCharacterType()
        {
            if (enemiesToSpawn.EnemyCharacterType == enemiesToKill.EnemyCharacterType)
                return enemiesToKill.EnemyCharacterType;
            return EnemyCharacterTypes.None;
        }

        public override EnemyController GetItem()
        {
            if (pool.FindAll(e => e.IsItemAvailable()).Count >= enemiesToSpawn.MaxEnemiesInScene)
                return null;

            return base.GetItem();
        }

        protected override EnemyController CreateItem()
        {
            return new EnemyController(GetRandomEnemyScriptableObject());
        }

        private EnemyScriptableObject GetRandomEnemyScriptableObject()
        {
            int index = Mathf.RoundToInt(Random.Range(0f, enemiesToSpawn.EnemyScriptableObjectList.Count - 1));

            return enemiesToSpawn.EnemyScriptableObjectList.GetByIndex(index);
        }
    }
}
