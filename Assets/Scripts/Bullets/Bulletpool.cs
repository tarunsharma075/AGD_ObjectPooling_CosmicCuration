using CosmicCuration.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class Bulletpool : GenericObjectPool<BulletController>
    {

        public BulletView bulletViewPrefab;
        public BulletScriptableObject bulletScriptableObject;


        public Bulletpool(BulletView bulletViewPrefab, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletViewPrefab = bulletViewPrefab;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public BulletController Getbullet() => GetItem();

        protected override void CreateItem()
        {
             new BulletController(bulletViewPrefab, bulletScriptableObject);
        }


    }
}