using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { // the class which controls the movement of the player in accordance to the wasd keys 
    public bool isMoving = false;
    public float speed = 5;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); //  the animation of the player 
	}
	
	// Update is called once per frame
	void Update () { // Moves the player when the w,s,a,d keys are pressed accordingly 

        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            isMoving = true;

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            isMoving = true;
            anim.SetFloat("Movement", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            isMoving = true;
            anim.SetFloat("Movement", 1);
        }
        if ((Input.GetKey(KeyCode.A)) != true && (Input.GetKey(KeyCode.D)) != true)
        {
            isMoving = false;
            anim.SetFloat("Movement", 0);
        }

    }
   
}
