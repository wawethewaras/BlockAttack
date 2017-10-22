using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour {

    [SerializeField]
    private UnitController enemy;


    private bool canSpawnUnit = true;

    void Start () {
		
	}
	
	void Update () {

	}

    void OnMouseDown()
    {
        if (canSpawnUnit && GameController.instance.EnoughResources(5)) {
            UnitController unit = Instantiate(enemy, transform.position, transform.rotation);
            GameController.instance.UseResources(5);
            StartCoroutine(GlobalCooldown());
        }

    }

    private IEnumerator GlobalCooldown() {
        canSpawnUnit = false;
        yield return new WaitForSeconds(0.5f);
        canSpawnUnit = true;

    }
}
