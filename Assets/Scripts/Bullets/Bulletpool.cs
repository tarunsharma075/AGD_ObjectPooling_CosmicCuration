using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
 public class Bulletpool 
    {

        public BulletView bulletViewPrefab;
        public BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets= new List<PooledBullet>();

        public Bulletpool(BulletView bulletViewPrefab, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletViewPrefab = bulletViewPrefab;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        
        public class PooledBullet
        {
           public  bool isUsed;
            public BulletController bulletController;
        }

        public BulletController Getbullet()
        {
            if (pooledBullets.Count>0)
            {
                PooledBullet pooledBullet= pooledBullets.Find(b => b.isUsed == false);
                if (pooledBullet != null) { 
                
                    pooledBullet.isUsed = true;
                    return pooledBullet.bulletController;
                }
            }

            return CreateNewPooledbulle();
        }

        private BulletController CreateNewPooledbulle()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bulletController = new BulletController(bulletViewPrefab, bulletScriptableObject);
            pooledBullet.isUsed = true;   
            pooledBullets.Add(pooledBullet);
            return pooledBullet.bulletController;
        }


        public void ReturningtoBulletPool(BulletController bullet)
        {
            PooledBullet pooledBullet = pooledBullets.Find(b => b.bulletController == bullet);
            pooledBullet.isUsed = false;
        }
    }
}