using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Utils;
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

        [SerializeField]
        private ParticleSystem explosionEffectPrefab;

        public int TotalEnemiesToSpawn { get; private set; }
        public int TotalEnemiesToKill { get; private set; }

        public ExplosionEffectPoolHandler ExplosionEffectPoolHandler { get; private set; }

        protected override void Initialize()
        {
            TotalEnemiesToSpawn = 0;
            foreach(EnemyCharacterTypes enemyCharacterType in GetEnemyCharacterTypes())
            {
                EnemiesToSpawn enemiesToSpawn = GetEnemiesToSpawn(enemyCharacterType);
                if (enemiesToSpawn != null)
                    TotalEnemiesToSpawn += enemiesToSpawn.NumberOfEnemies;
            }

            ExplosionEffectPoolHandler = new ExplosionEffectPoolHandler(explosionEffectPrefab);
        }

        public EnemyCharacterTypes[] GetEnemyCharacterTypes()
        {
            List<EnemyCharacterTypes> EnemyCharacterTypesList = new List<EnemyCharacterTypes>();

            List<EnemiesToSpawn> enemiesToSpawnList = levelScriptableObject.EnemiesToSpawnList;
            enemiesToSpawnList = enemiesToSpawnList.FindAll(e => e.NumberOfEnemies > 0 && e.MaxEnemiesInScene > 0 && e.EnemyCharacterType == e.EnemyScriptableObjectList.EnemyCharacterType);
            enemiesToSpawnList.ForEach(e => EnemyCharacterTypesList.Add(e.EnemyCharacterType));

            return EnemyCharacterTypesList.ToArray();
        }

        public EnemyCharacterTypes GetRandomEnemyCharacterType()
        {
            EnemyCharacterTypes[] EnemyCharacterTypesArray = GetEnemyCharacterTypes();
            if (EnemyCharacterTypesArray.Length < 1)
                return EnemyCharacterTypes.None;

            int index = Mathf.RoundToInt(Random.Range(0f, EnemyCharacterTypesArray.Length-1));
            return EnemyCharacterTypesArray[index];
        }

        public EnemiesToSpawn GetEnemiesToSpawn(EnemyCharacterTypes enemyCharacterType)
        {
            return levelScriptableObject.EnemiesToSpawnList.Find(e => e.EnemyCharacterType == enemyCharacterType);
        }

        public EnemiesToKill GetEnemiesToKill(EnemyCharacterTypes enemyCharacterType)
        {
            return levelScriptableObject.EnemiesToKillList.Find(e => e.EnemyCharacterType == enemyCharacterType);
        }
    }
}
