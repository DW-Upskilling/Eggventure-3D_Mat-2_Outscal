using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;


namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyService : Service<EnemyService>
    {
        [SerializeField]
        private List<EnemySpawner> enemySpawners;

        [SerializeField]
        private EnemyScriptableObjectList enemyScriptableObjectList;

        private EnemiesPoolHandler enemiesPoolHandler;

        private int enemiesToSpawn;
        private int enemiesSpawned;

        protected override void Initialize()
        {
            if (enemySpawners == null || enemySpawners.Count == 0)
                throw new UnassignedReferenceException("No spawners found");
            if(enemyScriptableObjectList == null || enemyScriptableObjectList.Count == 0)
                throw new UnassignedReferenceException("no enemies to spawn in the scene");

            LevelManager levelManager = LevelManager.Instance;

            enemiesToSpawn = levelManager.RegularEnemiesToSpawn;
            enemiesSpawned = 0;

            //enemiesPoolHandler = new EnemiesPoolHandler(levelManager.MaxEnemiesInTheScene);
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

            while (enemiesSpawned < enemiesToSpawn)
            {
                EnemySpawner enemySpawner = GetRandomEnemySpawner();
                if(enemySpawner != null) {
                    EnemyScriptableObject enemyScriptableObject = GetRandomEnemyScriptableObject();

                    if (enemyScriptableObject != null)
                    {
                        new EnemyController(enemyScriptableObject, enemySpawner.transform);
                        enemiesSpawned++;
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

        private EnemyScriptableObject GetRandomEnemyScriptableObject()
        {
            int index = Mathf.RoundToInt(Random.Range(1f, enemyScriptableObjectList.Count));
            return enemyScriptableObjectList.GetByIndex(index-1);
        }
    }
}
