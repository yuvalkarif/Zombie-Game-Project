using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour { // A class which controls the attacks of the enemy on the player 

    public int damage;
    public float attackRange;
    private float lastAttackTime;               // The enemies attack properties 
    public float attackDelay;
    Transform target;
    public Rigidbody2D rb;

  
    // CapsuleCollider2D capsuleCollider;
    private void Start()

    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // gets the position (Transform) of the player character 
      


        //  capsuleCollider = GetComponent<CapsuleCollider2D>();
    }



    void Update () { // Constantly checks if the enemy is in attack range of the player and if it is then it damages the player 

        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer < attackRange)
            {
                if (Time.time > lastAttackTime + attackDelay)
                {
                    Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                    if (player != null)
                    {
                        player.DamagePlayer(damage);
                       


                    }

                    lastAttackTime = Time.time;
                }

            }
        }
	}
   
}
