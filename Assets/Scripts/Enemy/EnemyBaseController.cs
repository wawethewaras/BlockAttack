using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseController : Building {

    
    void Start () {
    }

    void Update() {


    }

    public override void Destroyed() {
        GameController.Instance.goalCount--;
        if (GameController.Instance.goalCount <= 0)
        {

            StageManager.Instance.EnableNewStage();

        }
        myAudioSource.PlayOneShot(soundOnDamage, 0.3f);
        myAnimator.SetTrigger("Destroyed");
        GetComponent<Collider2D>().enabled = false;
        enabled = false;

    }


}
