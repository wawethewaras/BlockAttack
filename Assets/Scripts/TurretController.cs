using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    [SerializeField]
    private int attackRange;
    public LayerMask collisionLayerMask;

    [SerializeField]
    private BulletController bullet;

    [SerializeField]
    private float shootCoolDown;
    private bool canShoot = true;

    [SerializeField]
    private int health;

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
                if (Physics2D.Raycast(transform.position, Vector2.up, attackRange, collisionLayerMask))
                {
                    currentState = States.Attacking;
                }
                break;
            case States.Attacking:
                if (canShoot)
                {
                    BulletController temp = Instantiate(bullet, transform.position, transform.rotation);

                    StartCoroutine(ShootCooldown(shootCoolDown));
                }
                if (Physics2D.Raycast(transform.position, Vector2.down, attackRange, collisionLayerMask) == false)
                {
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
