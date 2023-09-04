using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;

using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemyView : CharacterView
    {
        [SerializeField]
        private EnemyPointOfView enemyPointOfView;
        public EnemyPointOfView EnemyPointOfView { get { return enemyPointOfView; } }

        [SerializeField]
        private EnemyRadar enemyRadar;
        public EnemyRadar EnemyRadar { get { return enemyRadar; } }

        private EnemyController enemyController;

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
