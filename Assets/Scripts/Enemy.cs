using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth;
		private int money;
		public int Money
		{
			get{ return money; }
			set{ money = value; }
		}
		private int points;
		public int Points
		{
			get{ return points; }
			set{ points = value; }
		}

        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
			money = 10;
			points = 20;
            currentHealth = maxHealth;
        }
    }
	Player player;
    public EnemyStats stats = new EnemyStats();

    [Header("Optional")]
    [SerializeField]
    private StatusIndicator statusIndicator;
    void Start()
    {
		player =  GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
			player.changeMoney (stats.Money);
			player.changePoints (stats.Points);
			player.SetMoneyText ();
			player.SetPointsText ();

        }
        if (statusIndicator != null)
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); };
    }
}

