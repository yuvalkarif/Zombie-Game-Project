using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmoPU : MonoBehaviour { // Max ammo power up 

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player") // if the player steps on the power up it sets his ammo to the max 
        {
            Weapon[] weapon = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponentsInChildren<Weapon>(); // finds the weapon currently equipped 
            if (weapon != null)
            {
                for (int i = 0; i < weapon.Length; i++)
                {
                    weapon[i].MaxAmmo(); // sets the ammo to the max 
                }
                
            }
            
            Destroy(this.gameObject);// destroys the power up
           
        }
    }
}
