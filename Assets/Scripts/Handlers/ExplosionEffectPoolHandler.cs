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
        private GameObject parent;

        public ExplosionEffectPoolHandler(ParticleSystem explosionEffect, GameObject parent) : base() {
            this.explosionEffect = explosionEffect;

            this.parent = parent;
        }

        protected override ParticleSystem CreateItem()
        {
            ParticleSystem particleSystem= GameObject.Instantiate<ParticleSystem>(explosionEffect, Vector3.zero, Quaternion.identity);
            particleSystem.gameObject.transform.SetParent(parent.transform);

            return particleSystem;
        }
    }
}
