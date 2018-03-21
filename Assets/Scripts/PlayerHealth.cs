using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour { 

    public int health = 100;



    public void TakeDamage(int damage)// damages the health of the player 
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject); // destroys the GameObject the script is connected to 
        }
    }
}
