using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Building {

    private const int shootRadius = 9;

    [SerializeField]
    private int attackRange;
    public LayerMask collisionLayerMask;

    [SerializeField]
    private BulletController bullet;

    [SerializeField]
    private float shootCoolDown;
    private bool canShoot = true;

    enum States
    {
        Idle,
        Attacking
    }
    States currentState = States.Idle;
    void Start () {
		
	}

	void Update () {

        switch (currentState)
        {
            case States.Idle:
                if (Physics2D.CircleCast(transform.position, shootRadius, Vector2.down, attackRange, collisionLayerMask))
                {
                    myAnimator.SetBool("isAttacking", true);
                    currentState = States.Attacking;
                }
                break;
            case States.Attacking:
                if (canShoot)
                {
                    Instantiate(bullet, transform.position, transform.rotation);

                    StartCoroutine(ShootCooldown(shootCoolDown));
                }
                if (Physics2D.CircleCast(transform.position, shootRadius, Vector2.down, attackRange, collisionLayerMask) == false)
                {
                    myAnimator.SetBool("isAttacking", false);

                    currentState = States.Idle;
                }
                break;

        }

	}

    public IEnumerator ShootCooldown(float cooldown) {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;


    }

}
