using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;

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

        public override void TakeDamage(Vandalizer vandalizer)
        {
            if (enemyController == null)
                return;
            enemyController.TakeDamage(vandalizer);
        }
    }
}
