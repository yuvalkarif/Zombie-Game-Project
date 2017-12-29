using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    Transform target;
    public Rigidbody2D rb;

  
    // CapsuleCollider2D capsuleCollider;
    private void Start()

    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      


        //  capsuleCollider = GetComponent<CapsuleCollider2D>();
    }



    void Update () {

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
