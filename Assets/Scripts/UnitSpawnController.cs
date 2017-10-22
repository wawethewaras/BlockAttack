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
        float offset = Random.Range(-2, 2);
        if (canSpawnUnit && GameController.instance.EnoughResources(5)) {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + offset);

            Instantiate(enemy, spawnPosition, transform.rotation);
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
