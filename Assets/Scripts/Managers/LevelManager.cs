using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Managers
{
    public class LevelManager : SceneSingleton<LevelManager>
    {
        [SerializeField]
        private LevelScriptableObject levelScriptableObject;

        public int TotalEnemiesToSpawn { get; private set; }

        protected override void Initialize()
        {
            TotalEnemiesToSpawn = 0;
            foreach(EnemyCharacterTypes enemyCharacterType in GetEnemyCharacterTypes())
            {
                EnemiesToSpawn enemiesToSpawn = GetEnemiesToSpawn(enemyCharacterType);
                if (enemiesToSpawn != null)
                    TotalEnemiesToSpawn += enemiesToSpawn.NumberOfEnemies;
            }
        }

        public EnemyCharacterTypes[] GetEnemyCharacterTypes()
        {
            List<EnemyCharacterTypes> EnemyCharacterTypesList = new List<EnemyCharacterTypes>();

            levelScriptableObject.EnemiesToSpawn.ForEach(e => EnemyCharacterTypesList.Add(e.EnemyCharacterType));

            return EnemyCharacterTypesList.ToArray();
        }

        public EnemyScriptableObjectList GetEnemyScriptableObjectList(EnemyCharacterTypes enemyCharacterType)
        {
            return levelScriptableObject.EnemyScriptableObjectLists.Find(e => e.EnemyCharacterType == enemyCharacterType);
        }

        public EnemiesToSpawn GetEnemiesToSpawn(EnemyCharacterTypes enemyCharacterType)
        {
            return levelScriptableObject.EnemiesToSpawn.Find(e => e.EnemyCharacterType == enemyCharacterType);
        }
    }
}
