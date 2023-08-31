using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses;

using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class EnemiesPoolHandler : ObjectPooling<EnemyController>
    {
        EnemiesPoolHandler(int numberOfEnemies): base(numberOfEnemies) { }
    }
}
