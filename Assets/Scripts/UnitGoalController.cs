using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitGoalController : MonoBehaviour {

    private string enemyTag = "Unit";

    private Health myHealth;

    public Text winGameText;
    public Text healthStatus;

    public static int goalCount = 0;

    public bool active;

    void Start () {
        myHealth = GetComponent<Health>();
        goalCount += 1;
        active = true;
    }

    void Update() {
        if (myHealth.CurrentHealth <= 0 && active) {
            active = false;
            goalCount--;
            gameObject.SetActive(false);
        }
        if (goalCount <= 0) {
            print("Game over!");
            winGameText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
