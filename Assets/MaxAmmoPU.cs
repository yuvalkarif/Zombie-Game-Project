using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmoPU : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            Weapon[] weapon = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponentsInChildren<Weapon>();
            if (weapon != null)
            {
                for (int i = 0; i < weapon.Length; i++)
                {
                    weapon[i].MaxAmmo();
                }
                
            }
            
            Destroy(this.gameObject);
           
        }
    }
}
