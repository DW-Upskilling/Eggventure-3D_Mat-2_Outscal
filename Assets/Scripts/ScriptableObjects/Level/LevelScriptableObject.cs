using System;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level
{
    [CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/Level/New")]
    public class LevelScriptableObject : ScriptableObject
    {
        [SerializeField]
        private int levelSequenceNumber;
        public int LevelSequenceNumber { get { return levelSequenceNumber; } }

        [SerializeField]
        private string levelName;
        public string LevelName { get { return levelName; } }

        [SerializeField]
        private List<EnemiesToSpawn> enemiesToSpawnList;
        public List<EnemiesToSpawn> EnemiesToSpawnList { get { return enemiesToSpawnList; } }

        [SerializeField]
        private List<EnemiesToKill> enemiesToKillList;
        public List<EnemiesToKill> EnemiesToKillList { get { return enemiesToKillList; } }
    }

    
    [Serializable]
    public class EnemiesToSpawn
    {

        [SerializeField]
        private EnemyScriptableObjectList enemyScriptableObjectList;
        public EnemyScriptableObjectList EnemyScriptableObjectList { get { return enemyScriptableObjectList; } }

        public EnemyCharacterTypes EnemyCharacterType;

        public int NumberOfEnemies;

        public int MaxEnemiesInScene;
    }

    [Serializable]
    public class EnemiesToKill
    {
        public EnemyCharacterTypes EnemyCharacterType;

        public int NumberOfEnemies;
    }
}
