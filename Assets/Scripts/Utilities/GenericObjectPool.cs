using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {

    private List<PooledItems<T>> pooledItem= new List <PooledItems<T>>();   


    protected T GetItem()
      {
       if(pooledItem.Count > 0)
        {
            PooledItems<T> item = pooledItem.Find(i => !i.isUsed);
            item.isUsed = true;
            return item.Item;
            }
            return CreatePooledItem();
      }


protected T CreatePooledItem()
        {
            PooledItems<T> item = new PooledItems<T>();
            item.Item = CreatePooledItem();
            item.isUsed = true;
            pooledItem.Add(item);
            return item.Item;
        }

        protected virtual  void  CreateItem()
        {
            throw new NotImplementedException();
        }

        public class PooledItems<T>
        {
            public T Item;
            public  bool isUsed;
        }


    public void ReturnThePooledItem(T item)
     {
        PooledItems<T> pooledItems = pooledItem.Find(i => i.Item == item);
        pooledItems.isUsed = false;

        }
        
    }
}