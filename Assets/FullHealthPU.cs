using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthPU : MonoBehaviour { // Power Up which sets the players health to the max when the player steps on it 



     void OnTriggerEnter2D(Collider2D other) // checks if the player steps on the power up 
    {
        
        if (other.gameObject.tag == "Player")
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.HealPlayer(); // heals the player 

            }
            
            Destroy(this.gameObject); // destroys the object 
       }
    }
}
