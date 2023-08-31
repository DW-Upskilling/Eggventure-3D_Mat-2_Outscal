using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyService : Service<EnemyService>
    {
        [SerializeField]
        private List<EnemySpawner> enemySpawners;

        private List<EnemiesPoolHandler> enemiesPool;

        private int enemiesSpawned;

        protected override void Initialize()
        {
            if (enemySpawners == null || enemySpawners.Count == 0)
                throw new UnassignedReferenceException("No spawners found");

            LevelManager levelManager = LevelManager.Instance;
            
            enemiesPool = new List<EnemiesPoolHandler>();
            foreach (EnemyCharacterTypes enemyCharacterType in levelManager.GetEnemyCharacterTypes())
            {
                EnemiesToSpawn enemiesToSpawn = levelManager.GetEnemiesToSpawn(enemyCharacterType);
                EnemiesToKill enemiesToKill = levelManager.GetEnemiesToKill(enemyCharacterType);

                if (enemiesToSpawn != null)
                    enemiesPool.Add(new EnemiesPoolHandler(enemiesToSpawn, enemiesToKill));
            }
        }

        protected override void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private void Update()
        {
            
        }

        IEnumerator SpawnEnemies()
        {
            yield return new WaitForSeconds(1f);

            while (enemiesSpawned < 10)
            {
                EnemySpawner enemySpawner = GetRandomEnemySpawner();
                if(enemySpawner != null) {
                    EnemiesPoolHandler enemiesPoolHandler = GetRandomEnemyPool();

                    if (enemiesPoolHandler != null)
                    {
                        EnemyController enemyController = enemiesPoolHandler.GetItem();
                        if (enemyController != null)
                        {
                            enemyController.SetSpawner(enemySpawner);
                            enemiesSpawned++;
                        }
                    }
                }
                yield return new WaitForSeconds(3f);
            }

            yield return null;
        }

        private EnemySpawner GetRandomEnemySpawner()
        {
            List<EnemySpawner> availableEnemySpawners = enemySpawners.FindAll(e => e.IsOccupied == false);
            if (availableEnemySpawners.Count < 1)
                return null;

            int index = Mathf.RoundToInt(Random.Range(1f, availableEnemySpawners.Count));
            return availableEnemySpawners[index - 1];
        }

        private EnemiesPoolHandler GetRandomEnemyPool()
        {
            int index = Mathf.RoundToInt(Random.Range(0f, enemiesPool.Count - 1));

            return enemiesPool[index];
        }
    }
}
