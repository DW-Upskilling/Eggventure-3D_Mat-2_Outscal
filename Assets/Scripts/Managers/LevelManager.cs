using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;

namespace Outscal.UnityAdvanced.Mat2.Managers
{
    public class LevelManager : SceneSingleton<LevelManager>
    {
        [SerializeField]
        private LevelScriptableObject levelScriptableObject;

        public int EnemiesToSpawn { get; private set; }

        protected override void Initialize()
        {
            EnemiesToSpawn = levelScriptableObject.EnemiesToSpawn;
        }
    }
}
