using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteRenderer))]

public class UnitController : MonoBehaviour {

    public AudioSource myAudioSource;
    public Animator myAnimator;
    public Health myHealth;
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

    [SerializeField]
    private AudioClip soundWhenDamage;

    enum States {
        Walking,
        Attacking
    }

    private States currentState = States.Walking;

    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myHealth = GetComponent<Health>();
        myAudioSource = GetComponent<AudioSource>();
        myHealth.tookDamage += PlaySoundOnDamage;
        myHealth.died += Dead;
    }

    void Update () {
        MoveToWayPoint();

    }

    public void MoveToWayPoint() {

        switch(currentState){
            case States.Walking:
                transform.Translate(Vector2.up * movespeed * Time.deltaTime);
                if (Physics2D.Raycast(transform.position, Vector2.up, attackRange, enemyCollisionLayerMask)) {
                    myAnimator.SetBool("isAttacking", true);
                    currentState = States.Attacking;
                }
                break;
            case States.Attacking:


                if (canShoot)
                {

                    StartCoroutine(ShootCooldown(shootCoolDown));
                }
                if (!Physics2D.Raycast(transform.position, Vector2.up, attackRange, enemyCollisionLayerMask))
                {
                    myAnimator.SetBool("isAttacking", false);

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

    public void Dead() {
        myAudioSource.PlayOneShot(soundWhenDamage, 0.3f);
        myAnimator.SetTrigger("Dead");
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
        mySpriteRenderer.sortingLayerName = "DeadBodies";
        GameController.Instance.unitInField.Remove(this);
    }

    void OnBecameInvisible()
    {
        GameController.Instance.unitInField.Remove(this);
        Destroy(gameObject);
    }

    public void PlaySoundOnDamage()
    {
        myAudioSource.PlayOneShot(soundWhenDamage);

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Bounds")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
