using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGoalController : MonoBehaviour {

    private string enemyTag = "Unit";

    void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == enemyTag) {
            print("doest damage");
            Destroy(other.gameObject);
        }

    }
}
