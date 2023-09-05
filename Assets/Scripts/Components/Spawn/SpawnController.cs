using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;

namespace Outscal.UnityAdvanced.Mat2.Components.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        public bool IsOccupied { get { return objectsEntry.Count > 0; } }

        List<Collider> objectsEntry;

        private void Awake()
        {
            objectsEntry = new List<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CharacterView characterView = other.gameObject.GetComponent<CharacterView>();
            if (characterView != null)
                objectsEntry.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            CharacterView characterView = other.gameObject.GetComponent<CharacterView>();
            if (characterView != null)
                objectsEntry.Remove(other);

            // Removing the objects if they were inactive
            List<Collider> objectsInactive = new List<Collider>();
            objectsEntry.ForEach(e => {
                if (e.gameObject.activeSelf == false)
                    objectsInactive.Add(e);
             });

            objectsInactive.ForEach(e => { objectsEntry.Remove(e); });
        }
    }
}
