using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupWeapon : MonoBehaviour { // this class allows the player to buy a weapon from a predefined place for a certain amount of money 

    public GameObject weaponToBuy;
    int weaponSwap=0;
    Player player;
    public int cost;
    public Text buyText;
    public GameObject textObject;
    


    void Start()
    {
        
        textObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D other) // checks if the player is on the place where he can buy the weapon 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
        if (other.gameObject.tag == "Player") // checks if the player steps on it 
        {
            textObject.SetActive(true);
            buyText.text = "PRESS (E) TO BUY THE WEAPON FOR: " + cost.ToString() + "$"; //  a UI appears that says how much the weapon costs 

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.money > cost)
                {
                    player.changeMoney(-cost);
                    player.SetMoneyText();
                    textObject.SetActive(false);

                    int wepNo = 0;


                    foreach (Transform weapon in other.transform.GetChild(0))
                    {

                        if (weapon.gameObject.activeSelf)
                        {
                            weaponSwap = wepNo;
                        }
                        wepNo++;
                    }

                    GameObject newWeapon = Instantiate(weaponToBuy, new Vector2(other.transform.GetChild(0).GetChild(weaponSwap).position.x, other.transform.GetChild(0).GetChild(weaponSwap).position.y), other.transform.GetChild(0).GetChild(weaponSwap).rotation); // places the weapon in the player 
                    newWeapon.transform.parent = other.transform.GetChild(0);
                    Destroy(other.transform.GetChild(0).GetChild(weaponSwap).gameObject);
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision) // if the player is no longer on the place it disables the text UI 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            if (textObject.activeSelf)
            {
                textObject.SetActive(false);
            }
        }


    }
}
