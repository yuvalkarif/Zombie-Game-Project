using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [System.Serializable]
    
    public class EnemyStats
    {
        [SerializeField]
        public int maxHealth;

        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            currentHealth = maxHealth;
            points = 20;
            money = 10;
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
    Player player;
    public void DamageEnemy(int damage)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            PowerUpDrop();
            GameMaster.KillEnemy(this);
            player.changeMoney(stats.Money);
            player.changePoints(stats.Points);
            player.SetMoneyText();
            player.SetPointsText();
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

