using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {

    private List<PooledItems<T>> pooledItem= new PooledItems<T>();




      public class PooledItems<T>
        {
            private T item;
            private bool isUsed;
        }
        
    }
}