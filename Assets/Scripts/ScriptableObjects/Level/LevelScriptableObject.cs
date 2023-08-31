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
        private List<EnemyScriptableObjectList> enemyScriptableObjectLists;
        public List<EnemyScriptableObjectList> EnemyScriptableObjectLists { get { return enemyScriptableObjectLists; } }

        [SerializeField]
        private List<EnemiesToSpawn> enemiesToSpawn;
        public List<EnemiesToSpawn> EnemiesToSpawn { get { return enemiesToSpawn; } }
    }

    
    [Serializable]
    public class EnemiesToSpawn
    {
        public EnemyCharacterTypes EnemyCharacterType;

        public int NumberOfEnemies;

        public int MaxEnemiesInScene;
    }
}
