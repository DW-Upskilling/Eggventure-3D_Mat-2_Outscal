using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyService : Service<EnemyService>
    {
        [SerializeField]
        private List<SpawnManager> spawnManagers;

        private List<EnemiesPoolHandler> enemiesPool;

        private int enemiesSpawned;

        protected override void Initialize()
        {
            if (spawnManagers == null || spawnManagers.Count == 0)
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
                SpawnManager spawnManager = GetRandomSpawnManager();
                if(spawnManager != null) {
                    EnemiesPoolHandler enemiesPoolHandler = GetRandomEnemyPool();

                    if (enemiesPoolHandler != null)
                    {
                        EnemyController enemyController = enemiesPoolHandler.GetItem();
                        if (enemyController != null)
                        {
                            enemyController.SetSpawner(spawnManager);
                            enemyController.SetEnemiesPoolHandler(enemiesPoolHandler);
                            enemiesSpawned++;
                        }
                    }
                }
                yield return new WaitForSeconds(3f);
            }

            yield return null;
        }

        private SpawnManager GetRandomSpawnManager()
        {
            List<SpawnManager> availableSpawners = spawnManagers.FindAll(e => e.IsOccupied == false);
            if (availableSpawners.Count < 1)
                return null;

            int index = Mathf.RoundToInt(Random.Range(1f, availableSpawners.Count));
            return availableSpawners[index - 1];
        }

        private EnemiesPoolHandler GetRandomEnemyPool()
        {
            int index = Mathf.RoundToInt(Random.Range(0f, enemiesPool.Count - 1));

            return enemiesPool[index];
        }
    }
}
