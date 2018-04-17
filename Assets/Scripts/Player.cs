using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour { // the class which holds the properties the player holds 
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth; // max health 
        [SerializeField]
        private int _currentHealth;// current health 
        public int currentHealth
        {   
           get {return _currentHealth;}
           set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init() // Initializes the the health value 
        {
            currentHealth = maxHealth;
        }
    }
    public PlayerStats playerStats = new PlayerStats();
    [Header("Optional")]
    [SerializeField]
    private StatusIndicator statusIndicator;
    public int money;
    public int points;
    public Text moneyText;
    public Text pointsText;
    public Text healthText;

    void Start() // Starts the UI properties of the player 
    {
        playerStats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth); };
        SetMoneyText();
        SetPointsText();
        SetHealthText();
    }

    

    public void DamagePlayer(int damage)// Function that causes the player to take dmg when recieved by the enemy 
    {
        playerStats.currentHealth -= damage;
        SetHealthText();
        if (playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void HealPlayer()// Sets the player's health to max 
    {
        playerStats.currentHealth = playerStats.maxHealth;
        
    }
    public void changeMoney(int change)// Changes the money of the player when he kills an enemy or buys a weapon 
    {
        money += change;
        SetMoneyText();
    }
    public void changePoints(int change) // adds points to the player 
    {
        points += change;
        SetPointsText();
    }
    public void SetMoneyText() // Controls the UI of the money 
    {
        moneyText.text = money.ToString() + "$";
    }
    public void SetPointsText() // Controls the UI of the points 
    {
        pointsText.text = "SCORE:" + points.ToString();
    }
    public void SetHealthText()// Controls the UI of the health 
    {
        healthText.text = playerStats.currentHealth + "/" +  playerStats.maxHealth + "HP";
    }
}
