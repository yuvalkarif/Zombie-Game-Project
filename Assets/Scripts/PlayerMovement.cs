using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { // the class which controls the movement of the player in accordance to the wasd keys 
    public bool isMoving = false;
    public float speed = 5;
    private Animator anim;
	
	private Dictionary<string,KeyCode> controls; 
    public Dictionary<string,KeyCode> Controls
    {
        get{return controls;}
        set{controls = value;}
    }

    KeyBinds k;

    KeyCode key;
	// Use this for initialization
	void Start () {
        //k = GameObject.FindGameObjectWithTag("KeyBind").GetComponent<KeyBinds>();
        anim = GetComponent<Animator>(); //  the animation of the player 
	    
		
	}
	
	// Update is called once per frame
	void Update () { // Moves the player when the w,s,a,d keys are pressed accordingly 


		if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Forward", "W"))))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            isMoving = true;

        }

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Backward", "S"))))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            isMoving = true;
        }
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Left", "A"))))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            isMoving = true;
            anim.SetFloat("Movement", -1);
        }
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Right", "D"))))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            isMoving = true;
            anim.SetFloat("Movement", 1);
        }
        if ((Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Left", "A")))) != true && (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Right", "D")))) != true)
        {
            isMoving = false;
            anim.SetFloat("Movement", 0);
        }

        

    }
    /*public void changeKey(KeyCode k , string name)
    {
        controls [name] = k;
    }
    public void SaveKeys()
	{
		foreach (var key in controls) {
			PlayerPrefs.SetString(key.Key, key.Value.ToString());
		}
		PlayerPrefs.Save ();
	}*/
   
}
