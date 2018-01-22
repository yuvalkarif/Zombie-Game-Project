using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth;
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
	public int money;
	public int points;
	public Text moneyText;
	public Text pointsText;
    private StatusIndicator statusIndicator;
    void Start()
    {
        playerStats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth); };
		money = 0;
		points = 0;
		SetMoneyText ();
		SetPointsText ();
    }

    

    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        if (playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
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
		moneyText.text = "Money = " + money.ToString();
	}
	public void SetPointsText()
	{
		pointsText.text = "Points = " + points.ToString();
	}
}
