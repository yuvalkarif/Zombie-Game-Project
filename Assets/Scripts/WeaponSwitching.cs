using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour { // switches the weapon 

    public int selectedWeapon;
	// Use this for initialization
	void Start () {

        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {//checks which weapon is selected and calls the function which swaps it to the other weapon 
        int previousSelected = selectedWeapon;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            
                
        }
        if (previousSelected != selectedWeapon)
            SelectWeapon();
	}

    void SelectWeapon() // changes the selected weapon 
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
