using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [System.Serializable]
    
    public class EnemyStats
    {
        [SerializeField]
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
            PowerUpDrop();
            GameMaster.KillEnemy(this);
        }
        if (statusIndicator != null)
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); };
    }

    [Header("PowerUps")]
    public GameObject[] PowerUps;

    void PowerUpDrop()
    {
        if (Random.value <= 0.5)
        {
            
            Instantiate(PowerUps[Random.Range(0,PowerUps.Length)], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}

