using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseController : Building {

    private bool alive = true;
    void Start () {
    }

    void Update() {


    }

    public override void Destroyed() {
        if (alive) {
            alive = false;
            GameController.Instance.goalCount--;
            GetComponent<Collider2D>().enabled = false;

            //gameObject.SetActive(false);
            myAudioSource.PlayOneShot(soundOnDamage, 0.3f);
            myAnimator.SetTrigger("Destroyed");
            myHealth.enabled = false;
            if (GameController.Instance.goalCount <= 0)
            {

                StageManager.Instance.EnableNewStage();

            }

            enabled = false;
        }


    }


}
