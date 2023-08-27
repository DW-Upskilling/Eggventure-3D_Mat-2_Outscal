using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ScriptableObjectList<T> : ScriptableObject
    {
        [SerializeField]
        List<T> items;
        
        public int Count { get { return items.Count; } }
        public T GetByIndex(int index)
        {
            return items[index];
        }
    }
}
