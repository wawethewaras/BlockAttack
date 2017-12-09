﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitController : MonoBehaviour {

    public SpriteRenderer mySpriteRenderer;
    public LayerMask enemyCollisionLayerMask;

    [SerializeField]
    public int resourceCost = 0;


    [SerializeField]
    private float movespeed;

    [SerializeField]
    private float attackRange;

    [SerializeField]
    private BulletController bullet;
    [SerializeField]
    private float shootCoolDown;
    private bool canShoot = true;

    enum States {
        Walking,
        Attacking
    }

    private States currentState = States.Walking;


	void Update () {
        MoveToWayPoint();

    }

    public void MoveToWayPoint() {

        switch(currentState){
            case States.Walking:
                transform.Translate(Vector2.down * movespeed * Time.deltaTime);
                if (Physics2D.Raycast(transform.position, Vector2.down, attackRange, enemyCollisionLayerMask)) {
                    currentState = States.Attacking;
                }
                break;
            case States.Attacking:


                if (canShoot)
                {

                    StartCoroutine(ShootCooldown(shootCoolDown));
                }
                if (!Physics2D.Raycast(transform.position, Vector2.down, attackRange, enemyCollisionLayerMask))
                {
                    currentState = States.Walking;
                }

                break;
            
        }

    }


    public IEnumerator ShootCooldown(float cooldown)
    {
        Instantiate(bullet, transform.position, transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }

}
