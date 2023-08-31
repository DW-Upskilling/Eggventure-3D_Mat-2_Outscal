using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses
{
    public abstract class ObjectPooling<T>
    {
        protected List<PoolItem<T>> pool;

        public ObjectPooling(){
            pool = new List<PoolItem<T>>();
        }

        public virtual T GetItem()
        {
            PoolItem<T> poolItem = pool.Find(e => e.IsItemAvailable() && e.SetItemAvailablility(false));
            if (poolItem == null) 
                poolItem = createNewPoolItem();

            poolItem.SetItemAvailablility(false);
            
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

        protected abstract T CreateItem();

        private PoolItem<T> createNewPoolItem()
        {
            PoolItem<T> poolItem = new PoolItem<T>(CreateItem());
            pool.Add(poolItem);

            return poolItem;
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
