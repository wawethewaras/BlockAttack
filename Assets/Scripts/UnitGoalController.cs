using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitGoalController : MonoBehaviour {

    private string enemyTag = "Unit";

    private Health myHealth;

    public Text winGameText;
    public Text healthStatus;

    void Start () {
        myHealth = GetComponent<Health>();

    }

    void Update() {
        if (myHealth.CurrentHealth <= 5) {
            print("Game over!");
            winGameText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
