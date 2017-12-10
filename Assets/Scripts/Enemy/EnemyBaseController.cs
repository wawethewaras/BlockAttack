using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseController : Building {

    public static int goalCount = 0;

    public bool active;

    void Start () {
        goalCount += 1;
        active = true;
        myHealth.died += RemoveGoal;
    }

    void Update() {


    }

    public void RemoveGoal() {
        active = false;
        goalCount--;
        if (goalCount <= 0)
        {
            print("Game over!");
            WinGameUI.Instance.WinGame();
            Time.timeScale = 0;
        }
        gameObject.SetActive(false);

    }
}
