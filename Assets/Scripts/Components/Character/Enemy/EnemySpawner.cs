using System.Collections.Generic;
using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.Components.Character.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public bool IsOccupied { get { return objectsEntry.Count > 0; } }

        List<Collider> objectsEntry;

        private void Awake()
        {
            objectsEntry = new List<Collider>();
        }

        private void OnTriggerStay(Collider other)
        {
            objectsEntry.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            objectsEntry.Remove(other);
        }
    }
}
