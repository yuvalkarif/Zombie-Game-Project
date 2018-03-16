using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private StatusIndicator statusIndicator;
    void Start()
    {
        playerStats.Init();
        if (statusIndicator != null)
        { statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth); };
    }

    

    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        if (playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}
