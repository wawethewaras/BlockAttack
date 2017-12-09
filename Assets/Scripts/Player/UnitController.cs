using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    [SerializeField]
    private float movespeed;

    [SerializeField]
    private float attackRange;

    private Health myHealth;
    public LayerMask collisionLayerMask;

    public Health Enemy;

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

    void Start() {
        myHealth = GetComponent<Health>();
    }

	void Update () {
        MoveToWayPoint();

    }

    public void MoveToWayPoint() {

        switch(currentState){
            case States.Walking:
                transform.Translate(Vector2.down * movespeed * Time.deltaTime);
                Debug.DrawRay(transform.position, Vector2.down, Color.green);
                RaycastHit2D enemy;
                if (enemy = Physics2D.Raycast(transform.position, Vector2.down, attackRange, collisionLayerMask)) {
                    Enemy = enemy.collider.GetComponent<Health>();
                    currentState = States.Attacking;
                }
                break;
            case States.Attacking:


                if (canShoot)
                {
                    Instantiate(bullet, transform.position, transform.rotation);

                    StartCoroutine(ShootCooldown(shootCoolDown));
                }
                //if (Enemy == null)
                //{
                //    currentState = States.Walking;
                //}
                if (!Physics2D.Raycast(transform.position, Vector2.down, attackRange, collisionLayerMask))
                {
                    currentState = States.Walking;
                }

                break;
            
        }

    }


    public IEnumerator ShootCooldown(float cooldown)
    {
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
