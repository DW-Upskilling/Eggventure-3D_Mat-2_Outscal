using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ObjectPooling<T>
    {
        private List<PoolItem<T>> pool;
        private int numberOfObjects;

        public ObjectPooling(int noOfObjects){
            numberOfObjects = noOfObjects;

            pool = new List<PoolItem<T>>(numberOfObjects);
        }

        public T GetItem()
        {
            PoolItem<T> poolItem = pool.Find(e => e.IsItemAvailable() && e.SetItemAvailablility(false));
            if (poolItem == null)
                return default(T);
            
            return poolItem.Item;
        }

        public void ReturnItem(T item)
        {
            PoolItem<T> poolItem = pool.Find(e => e.Item.Equals(item));
            if(poolItem != null)
            {
                poolItem.SetItemAvailablility(true);
            }
        }
    }

    public class PoolItem<T>
    {
        public T Item { get; private set; }
        
        private bool inUse;

        public PoolItem(T item) { Item = item; inUse = false; }
        public bool IsItemAvailable() { return !inUse; }
        public bool SetItemAvailablility(bool state)
        {
            if(state == inUse && inUse == true)
            {
                inUse = false;
                return true;
            } else if(state == inUse && inUse == false)
            {
                inUse = true;
                return true;
            }
            return false;
        }
    }
}
