using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour {

    public GameObject weaponToBuy;
    int weaponSwap=0;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                int wepNo = 0;

                
                foreach (Transform weapon in other.transform.GetChild(0))
                {
                    
                    if (weapon.gameObject.activeSelf)
                    { 
                        weaponSwap = wepNo;
                    }
                    wepNo++;
                }
                GameObject newWeapon = Instantiate(weaponToBuy, new Vector2(other.transform.GetChild(0).GetChild(weaponSwap).position.x, other.transform.GetChild(0).GetChild(weaponSwap).position.y), other.transform.GetChild(0).GetChild(weaponSwap).rotation);
                newWeapon.transform.parent = other.transform.GetChild(0);
                Destroy(other.transform.GetChild(0).GetChild(weaponSwap).gameObject);

            }
        }

    }
}
