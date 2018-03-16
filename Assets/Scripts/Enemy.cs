using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth;
        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            currentHealth = maxHealth;
        }
    }

    public EnemyStats stats = new EnemyStats();

    [Header("Optional")]
    [SerializeField]
    private StatusIndicator statusIndicator;
    void Start()
    {
        stats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); };
    }

    public void DamageEnemy(int damage)
    {
       stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }
        if (statusIndicator != null)
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); };
    }
}

