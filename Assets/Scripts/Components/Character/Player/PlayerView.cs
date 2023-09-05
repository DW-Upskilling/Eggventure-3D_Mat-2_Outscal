using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

using Outscal.UnityAdvanced.Mat2.Utils.Interfaces;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Player
{
    public class PlayerView : CharacterView
    {
        [SerializeField]
        private Transform firstPersonModeCameraTransform;
        public Transform FirstPersonModeCameraTransform { get { return firstPersonModeCameraTransform; } }

        [SerializeField]
        private Transform thirdPersonModeCameraTransform;
        public Transform ThirdPersonModeCameraTransform { get { return thirdPersonModeCameraTransform; } }

        private PlayerController playerController;

        public override void TakeDamage(Vandalizer vandalizer)
        {
            if (playerController == null)
                return;
            playerController.TakeDamage(vandalizer);
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            if (playerController == null)
                return;

            playerController.Start();
            base.Start();
        }

        protected override void Update()
        {
            if (playerController == null)
                return;

            base.Update();
            playerController.HandleUserInput();
        }

        protected override void LateUpdate()
        {
            if (playerController == null)
                return;

            base.LateUpdate();
            playerController.UpdateCameraPosition();
        }

        protected override void FixedUpdate()
        {
            if (playerController == null)
                return;

            base.FixedUpdate();
            playerController.FixedUpdate();
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }
    }
}
