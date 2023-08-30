using UnityEngine;

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
        private int enemiesToSpawn;
        public int EnemiesToSpawn { get { return enemiesToSpawn; } }
    }
}
