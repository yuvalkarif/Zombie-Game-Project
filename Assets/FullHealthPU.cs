using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthPU : MonoBehaviour {



     void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer(-player.playerStats.maxHealth);

            }
            
            Destroy(this.gameObject);
       }
    }
}
