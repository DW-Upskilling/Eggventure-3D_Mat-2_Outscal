using UnityEngine;

using Outscal.UnityAdvanced.Mat2.ScriptableObjects.Character;
using Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController;

namespace Outscal.UnityAdvanced.Mat2.Components.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterView : View
    {
        public Vector3 Position { set; get; }
        public Quaternion Rotation { set; get; }

        public bool isModified;

        protected Rigidbody rb;

        protected virtual void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody>();

            Position = gameObject.transform.position;
            Rotation = gameObject.transform.rotation;

            isModified = false;
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            
        }

        protected virtual void LateUpdate() {
            if (isModified)
            {
                Debug.Log(Position);

                Transform transform = gameObject.transform;

                Vector3 position = transform.position;
                position.x += Position.x;
                position.y += Position.y;
                position.z += Position.z;

                transform.position = position;

                isModified = false;
            }
        }

    }
}
