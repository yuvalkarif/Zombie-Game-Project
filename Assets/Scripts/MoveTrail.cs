using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = 230;

    void Update()
    {
        transform.Translate (Vector3.right*Time.deltaTime*moveSpeed);
        Destroy(gameObject, 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
