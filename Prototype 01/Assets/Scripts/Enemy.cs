using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public class EnemyStats
    {
        public int health = 100;
    }

    public EnemyStats stats = new EnemyStats();

    public void DamageEnemy(int damage)
    {
       stats.health -= damage;
        if (stats.health <= 0)
        {
            GameMaster.KillEnemy(this);
        }
    }
}

