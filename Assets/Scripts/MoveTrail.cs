using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = 230;

    void Update() // Moves the object referenced 
    {
        transform.Translate (Vector3.right*Time.deltaTime*moveSpeed); // A vector in 3d 
        Destroy(gameObject, 1);
    }
    void OnTriggerEnter2D(Collider2D other) // Destroys the Object 
    {
        if (other.gameObject.tag != "Player")
            Destroy(gameObject);
        
    }
}
