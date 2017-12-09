using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour {


    private bool canSpawnUnit = true;

    private SpriteRenderer myRenderer;
    void Awake () {
        myRenderer = GetComponent<SpriteRenderer>();

    }
	
	void Update () {

	}

    //void OnMouseDown()
    //{
    //    float offset = Random.Range(-2, 2);
    //    if (canSpawnUnit && GameController.instance.EnoughResources(5) && GameController.instance.myUnitMouse.unitPlacedOnClick != null) {
    //        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + offset);

    //        Instantiate(GameController.instance.myUnitMouse.unitPlacedOnClick, spawnPosition, transform.rotation);
    //        GameController.instance.UseResources(5);
    //        StartCoroutine(GlobalCooldown());
    //    }

    //}

    void OnMouseEnter()
    {
        myRenderer.color = new Color(0.7f, 0.7f, 0.7f, 0.5f);
        GameController.instance.currentSpawnArea = this;
    }

    void OnMouseExit()
    {
        myRenderer.color = Color.white;
        GameController.instance.currentSpawnArea = null;
    }

    private IEnumerator GlobalCooldown() {
        canSpawnUnit = false;
        yield return new WaitForSeconds(0.5f);
        canSpawnUnit = true;

    }
}
