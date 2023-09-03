using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Level;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Enemy;
using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class ExplosionEffectPoolHandler : ObjectPooling<ParticleSystem>
    {
        private ParticleSystem explosionEffect;

        public ExplosionEffectPoolHandler(ParticleSystem explosionEffect) : base() {
            this.explosionEffect = explosionEffect;
        }

        protected override ParticleSystem CreateItem()
        {
            return GameObject.Instantiate<ParticleSystem>(explosionEffect, Vector3.zero, Quaternion.identity);
        }
    }
}
