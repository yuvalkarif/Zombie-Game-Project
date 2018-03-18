using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth;
        [SerializeField]
        private int _currentHealth;
        public int currentHealth
        {   
           get {return _currentHealth;}
           set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
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

    void Start()
    {
        playerStats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth); };
        SetMoneyText();
        SetPointsText();
        SetHealthText();
    }

    

    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        SetHealthText();
        if (playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void HealPlayer()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        
    }
    public void changeMoney(int change)
    {
        money += change;
    }
    public void changePoints(int change)
    {
        points += change;
    }
    public void SetMoneyText()
    {
        moneyText.text = money.ToString() + "$";
    }
    public void SetPointsText()
    {
        pointsText.text = "SCORE:" + points.ToString();
    }
    public void SetHealthText()
    {
        healthText.text = playerStats.currentHealth + "/" +  playerStats.maxHealth + "HP";
    }
}
