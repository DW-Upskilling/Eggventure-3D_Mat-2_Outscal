using System.Collections;
using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.Utils.Interfaces
{
    public interface Vandalizer
    {
        public void DoDamage(Damageable damageable);

        public float GetDamage();
    }
}
