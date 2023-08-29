using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;
using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character.Player;

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

        [SerializeField]
        private Transform playerDirectionTransform;
        public Transform PlayerDirectionTransform { get { return playerDirectionTransform; } }

        private PlayerController playerController;

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
            playerController.HandlerUserInput();
        }

        protected override void LateUpdate()
        {
            if (playerController == null)
                return;

            base.LateUpdate();
            playerController.UpdateCameraPosition();
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }
    }
}
