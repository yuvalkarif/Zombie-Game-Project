using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    GameObject player;
    //bool followPlayer = true;
    public float m_Speed=0.1f;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, m_Speed) + new Vector3(0, 0, -10);
		
	}
}
