using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyView : CharacterView
    {
        private EnemyController enemyController;

        protected override void Start()
        {
            if (enemyController == null)
                return;

            enemyController.Start();
            base.Start();
        }

        public void SetController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public EnemyController GetEnemyController()
        {
            return enemyController;
        }
    }
}
