using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteRenderer))]
public class Building : MonoBehaviour {

    protected Health myHealth;
    protected Animator myAnimator;
    protected AudioSource myAudioSource;

    [SerializeField]
    protected AudioClip soundOnDamage;
    [SerializeField]
    protected AudioClip soundOnDestruction;

    // Use this for initialization
    public virtual void Awake () {
        myHealth = GetComponent<Health>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();

        myHealth.tookDamage += PlaySoundOnDamage;
        myHealth.died += Destroyed;
    }


    public virtual void Destroyed()
    {
        myHealth.enabled = false;
        myAudioSource.PlayOneShot(soundOnDamage, 0.3f);
        myAnimator.SetTrigger("Destroyed");
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }

    public void PlaySoundOnDamage() {
        myAudioSource.PlayOneShot(soundOnDamage,0.3f);

    }
}
