using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    Transform target;
    public float distance;
    public bool canMove = true;
    public float knockBack = 100f;

    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	
	void Update () {
        if (canMove)
        {
            if (target != null)
            {
                if (Vector2.Distance(transform.position, target.position) > distance)
                { transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); }
            }
        }
	}
   
}

