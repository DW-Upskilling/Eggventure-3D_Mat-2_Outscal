using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ScriptableObjectList<T> : ScriptableObject where T: ScriptableObject
    {
        [SerializeField]
        private List<T> items;
        
        public int Count { get { return items.Count; } }
        public T GetByIndex(int index)
        {
            if (items == null || index < 0 || index >= items.Count)
                return null;
            return items[index];
        }
    }
}
