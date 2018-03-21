using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The Class which holds the properties of the Enemy 
public class Enemy : MonoBehaviour {
    [System.Serializable]
    
    public class EnemyStats //The enemy's stats 
    {
        [SerializeField]
        public int maxHealth;

        private int points; // Points the enemy is worth
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        private int money;// The money the enemy is worth 
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        private int _currentHealth;// Health the enemy has 
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init() // a function that sets the initial values of the enemy's properties
        {
            currentHealth = maxHealth;
            points = 20;
            money = 10;
        }
    }

    public EnemyStats stats = new EnemyStats();

    [Header("Optional")]
    [SerializeField]
    private StatusIndicator statusIndicator; // a object of the class statusIndicator
    void Start()
    {
        stats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); }; // The Ui of the enemy's properties
    }
    Player player;
    public void DamageEnemy(int damage) // A function the controls the damage a enemy recieves 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // gets the position of the player 
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
        { statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth); }; // changes the values on the UI 
    }

    [Header("PowerUps")]
    public GameObject[] PowerUps;

    void PowerUpDrop() // A func which controls the Power Ups dropped from the enemy  
    {
        if (Random.value <= 0.5)
        {
            
            Instantiate(PowerUps[Random.Range(0,PowerUps.Length)], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}

