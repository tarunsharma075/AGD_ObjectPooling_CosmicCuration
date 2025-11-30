using CosmicCuration.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{

    private List<PooledEnemy> pooledEnemies= new List<PooledEnemy>();
    private EnemyData enemydata;
    private EnemyView enemyViewPrefab;


    public EnemyPool(EnemyView enemyViewPrefab, EnemyData enemydata)
    {
        this.enemyViewPrefab = enemyViewPrefab;
        this.enemydata = enemydata;
    }
    public  class PooledEnemy
    {
        public EnemyController enemy;
        public bool inUse;
    }

    public EnemyController GetEnemy()
    {
        if (pooledEnemies.Count > 0)
        {
            PooledEnemy enemy = pooledEnemies.Find(item => !item.inUse);
            if (enemy != null)
            {
                enemy.inUse = true;
                return enemy.enemy;
            }
        }
        return CreateNewPooledEnemy();
    }

    private EnemyController CreateNewPooledEnemy()
    {
      PooledEnemy enemy = new PooledEnemy();
        enemy.enemy = new EnemyController(enemyViewPrefab,enemydata);
        enemy.inUse = true;
        pooledEnemies.Add(enemy);
        return enemy.enemy;
    }



    public void ReturnTheEnemy(EnemyController enemyController)
    {
        PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.enemy == enemyController);
        pooledEnemy.inUse = false;
    }
}
