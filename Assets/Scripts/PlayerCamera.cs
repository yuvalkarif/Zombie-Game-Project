using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour { // makes the camere center on the position of the player 
    GameObject player;
    //bool followPlayer = true;
    public float m_Speed=0.1f;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); // creates a Player type object
		
	}
	
	// Update is called once per frame
	void Update () { // sets the positio of the camera to center on the player position 
        //Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        if (player!=null)
        transform.position = Vector3.Lerp(transform.position, player.transform.position, m_Speed) + new Vector3(0, 0, -10);
		
	}
}
