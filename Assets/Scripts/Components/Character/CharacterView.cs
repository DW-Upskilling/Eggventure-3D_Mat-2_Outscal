using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Utils;

using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterView : View, Damageable
    {
        [SerializeField]
        private Transform characterDirectionTransform;
        public Transform CharacterDirectionTransform { get { return characterDirectionTransform; } }

        [SerializeField]
        private Transform muzzlePointTransform;
        public Transform MuzzlePointTransform { get { return muzzlePointTransform; } }

        [SerializeField]
        private ParticleSystem muzzlePointParticlesStart;
        public ParticleSystem MuzzlePointParticlesStart { get { return muzzlePointParticlesStart; } }

        [SerializeField]
        private ParticleSystem muzzlePointParticlesEnd;
        public ParticleSystem MuzzlePointParticlesEnd { get { return muzzlePointParticlesEnd; } }

        public Vector3 Position { set; get; }
        public Quaternion Rotation { set; get; }
        public Vector3 Force { set; get; }
        public Vector3 Velocity { get { return rb.velocity; } set { rb.velocity = value; } }
        public ForceMode ForceMode { set; get; }

        public bool usePosition { set; get; }
        public bool useRotation { set; get; } 
        public bool useRigidBody { set; get; }

        protected Rigidbody rb;

        protected virtual void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody>();

            Position = gameObject.transform.position;
            Rotation = gameObject.transform.rotation;

            usePosition = false;
            useRotation = false;
            useRigidBody = false;
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            
        }

        protected virtual void LateUpdate() {

            Transform transform = gameObject.transform;
            if (usePosition)
            {
                Vector3 position = transform.position;
                position.x += Position.x;
                position.y += Position.y;
                position.z += Position.z;

                transform.position = position;
                usePosition = false;
            }

            if (useRotation)
            {
                Quaternion rotation = transform.rotation;
                rotation.x += Rotation.x;
                rotation.y += Rotation.y;
                rotation.z += Rotation.z;

                transform.rotation = rotation;
                useRotation = false;
            }

            if (useRigidBody)
            {
                rb.AddForce(Force, ForceMode);
                useRigidBody = false;
            }
        }

        protected virtual void FixedUpdate()
        {
            
        }

        public virtual void TakeDamage(Vandalizer vandalizer)
        {
            float damage = vandalizer.GetDamage();
            Debug.Log(gameObject.name + " damaged for " + damage);
        }

    }
}
