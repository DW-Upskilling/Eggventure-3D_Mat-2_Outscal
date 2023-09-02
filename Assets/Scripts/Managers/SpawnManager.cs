using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Components.Character;

namespace Outscal.UnityAdvanced.Mat2.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public bool IsOccupied { get { return objectsEntry.Count > 0; } }

        List<Collider> objectsEntry;

        private void Awake()
        {
            objectsEntry = new List<Collider>();
        }

        private void OnTriggerStay(Collider other)
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
        }
    }
}
