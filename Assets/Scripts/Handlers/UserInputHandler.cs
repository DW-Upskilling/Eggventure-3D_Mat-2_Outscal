using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class UserInputHandler
    {
        public float mouseX { get; private set; } 
        public float mouseY { get; private set; }

        public bool mouseLeftClickDown { get; private set; }
        public bool mouseLeftClickUp { get; private set; }

        public float horizontal { get; private set; }
        public float vertical { get; private set; }

        public float sprint { get; private set; }

        public UserInputHandler()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Update()
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            mouseLeftClickDown = Input.GetMouseButtonDown(0);
            mouseLeftClickUp = Input.GetMouseButtonUp(0);

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            sprint = Input.GetAxis("Sprint");
        }
    }
}
