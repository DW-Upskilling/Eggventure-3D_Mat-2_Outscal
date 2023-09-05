using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Handlers;
using Outscal.UnityAdvanced.Mat2.Events;
using Outscal.UnityAdvanced.Mat2.Managers;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.Components.Spawn;
using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;
using Outscal.UnityAdvanced.Mat2.Components.Character.Enemy;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    public abstract class CharacterController<T, U, V> : Controller, Vandalizer
        where T: CharacterScriptableObject
        where U : CharacterView
        where V: CharacterModel<T>
    {
        protected V characterModel;
        protected U characterView;

        protected float movementHorizontal { get; set; }
        protected float movementVertical { get; set; }
        protected float movementSprint { get; set; }

        protected float rotationHorizontal { get; set; }
        protected float rotationVertical { get; set; }

        public float MovementSpeed { get { return characterModel.CharacterScriptableObject.MovementSpeed; } }

        private LevelManager levelManager;

        private ExplosionEffectPoolHandler explosionEffectPoolHandler;

        private Transform characterDirectionTransform;
        private Transform muzzlePointTransform;

        private LineRenderer laserBeam;

        private ParticleSystem muzzlePointParticlesStart;
        private ParticleSystem muzzlePointParticlesEnd;

        private List<ParticleSystem> explosions;

        private KillEventHandler killEventHandler;
        private DeathEventHandler deathEventHandler;

        public CharacterController(T characterScriptableObject)
        {
            characterModel = CreateCharacterModel(characterScriptableObject);
            characterView = InstantiateCharacterView(characterScriptableObject);

            levelManager = LevelManager.Instance;
            explosionEffectPoolHandler = levelManager.ExplosionEffectPoolHandler;

            characterDirectionTransform = characterView.CharacterDirectionTransform;
            muzzlePointTransform = characterView.MuzzlePointTransform;

            laserBeam = characterDirectionTransform.GetComponent<LineRenderer>();
            laserBeam.enabled = false;

            muzzlePointParticlesStart = characterView.MuzzlePointParticlesStart;
            muzzlePointParticlesEnd = characterView.MuzzlePointParticlesEnd;

            explosions = new List<ParticleSystem>();

            killEventHandler = KillEventHandler.Instance;
            deathEventHandler = DeathEventHandler.Instance;
        }

        public virtual void FixedUpdate()
        {
            float laserDistance = characterModel.CharacterScriptableObject.LaserDistance;

            Ray ray = new Ray(muzzlePointTransform.position, muzzlePointTransform.forward);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, laserDistance);

            Vector3 hitPosition = cast ? hit.point : muzzlePointTransform.position + muzzlePointTransform.forward * laserDistance;

            laserBeam.SetPosition(0, muzzlePointTransform.position);
            laserBeam.SetPosition(1, hitPosition);

            muzzlePointParticlesEnd.transform.position = hitPosition;

            if (laserBeam.enabled)
            {
                if (cast)
                {
                    Damageable damageable = hit.collider.gameObject.GetComponent<Damageable>();
                    if (damageable != null)
                        damageable.TakeDamage((Vandalizer)this);
                }

                ParticleSystem explosion = explosionEffectPoolHandler.GetItem();

                explosion.gameObject.transform.position = muzzlePointParticlesEnd.transform.position;
                explosion.Play();

                explosions.Add(explosion);
            }

            explosions.FindAll(e => e.isStopped || e.isPaused || !e.IsAlive()).ForEach(e =>
            {
                explosionEffectPoolHandler.ReturnItem(e);
                explosions.Remove(e);
            });
        }

        public void TakeDamage(Vandalizer vandalizer)
        {
            float damage = vandalizer.GetDamage();
            characterModel.Health -= damage;
            
            if(characterModel.Health < 1) {
                switch (characterModel.CharacterScriptableObject.CharacterType)
                {
                    case CharacterTypes.Enemy:
                        killEventHandler.TriggerKillEvent(characterView);
                        break;
                    case CharacterTypes.Player:
                        deathEventHandler.TriggerDeathEvent(characterView);
                        break;
                }
                Destroy();
            }
        }

        public void DoDamage(Damageable damageable)
        {
            damageable.TakeDamage((Vandalizer)this);
        }

        public float GetDamage()
        {
            return 100f;
        }

        public virtual void Move()
        {
            Vector3 moveForwardDirection = characterDirectionTransform.forward * movementVertical;
            Vector3 moveRightDirection = characterDirectionTransform.right * movementHorizontal;

            Vector3 moveDirection = moveForwardDirection + moveRightDirection;

            HandleMovement(moveDirection);
            HandleMovementSpeed();
        }

        public virtual void HandleRotation()
        {
            characterModel.xRotation -= rotationHorizontal * characterModel.CharacterScriptableObject.XAxisSenstivity;
            characterModel.xRotation = Mathf.Clamp(characterModel.xRotation, -90f, 90f);
            characterModel.yRotation += rotationVertical * characterModel.CharacterScriptableObject.YAxisSenstivity;

            Quaternion rotation = Quaternion.Euler(characterModel.xRotation, characterModel.yRotation, 0);
            characterDirectionTransform.rotation = rotation;
            muzzlePointTransform.rotation = rotation;
        }

        protected void ActivateLaser()
        {
            if (laserBeam.enabled) return;

            laserBeam.enabled = true;

            muzzlePointParticlesStart.Play();
            muzzlePointParticlesEnd.Play();
        }
        protected void DeactivateLaser()
        {
            if (!laserBeam.enabled) return;

            laserBeam.enabled = false;
            laserBeam.SetPosition(0, muzzlePointTransform.position);
            laserBeam.SetPosition(1, muzzlePointTransform.position);

            muzzlePointParticlesStart.Stop();
            muzzlePointParticlesEnd.Stop();
        }

        private void HandleMovement(Vector3 moveDirection)
        {
            float speedMultiplier = 1f;
            if (movementSprint != 0)
                speedMultiplier += .5f;

            moveDirection *= speedMultiplier;
            moveDirection.y = 0f;

            characterView.Force = moveDirection.normalized * MovementSpeed;
            characterView.ForceMode = ForceMode.Force;
            characterView.useRigidBody = true;
        }

        private void HandleMovementSpeed()
        {
            Vector3 currentVelocity = characterView.Velocity;
            Vector3 flatVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

            float maxSpeed = MovementSpeed;
            if(movementSprint != 0)
                maxSpeed += maxSpeed * 0.5f;

            if (flatVelocity.magnitude > maxSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * MovementSpeed;
                characterView.Velocity = new Vector3(limitedVelocity.x, currentVelocity.y, limitedVelocity.z);
            }
        }

        public abstract void Start();
        public abstract void SetActive(bool state);
        public abstract void SetSpawner(SpawnController spawnManager);

        protected abstract void Destroy();
        protected abstract V CreateCharacterModel(T characterScriptableObject);
        protected abstract U InstantiateCharacterView(T characterScriptableObject);
    }
}
