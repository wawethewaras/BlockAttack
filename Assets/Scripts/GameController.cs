using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : Singleton<GameController> {

    public int resouces;

    public UnitController[] unitPlayerHas;

    public UnitController myUnitMouse { set; get; }

    private UnitUIController currentUnitUIController;
    private bool canSpawnUnit = true;

    public event Action resourcesAltered;

    public void ResourcesAltered() {
        if (resourcesAltered != null) {
            resourcesAltered();
        }
    }

    private CursorController theCursor;

    void Start () {
        theCursor = CursorController.Instance;
        DisableSpawnAreas();
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && myUnitMouse != null && GameController.instance.EnoughResources(myUnitMouse.resourceCost)) {
            MouseHeldDown();
        }
        if (Input.GetMouseButtonUp(0) && UnitSpawnController.currentSpawnArea != null) {
            SpawnUnit();
        }
        theCursor.cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public bool EnoughResources(int amount) {
        return resouces >= amount;
    }

    public void UseResources(int amount)
    {
        resouces -= amount;
        ResourcesAltered();
    }
    public void AddResources(int amount) {
        resouces += amount;
        ResourcesAltered();
    }

    public void EnableSpawnAreas() {
        foreach(UnitSpawnController game in UnitSpawnController.spawnAreas) {
            game.gameObject.SetActive(true);
        }
    }
    public void DisableSpawnAreas() {
        foreach (UnitSpawnController game in UnitSpawnController.spawnAreas)
        {
            game.gameObject.SetActive(false);
        }
    }

    public void MouseHeldDown()
    {
        StartCoroutine(WhileMouseDown());
    }

    private IEnumerator WhileMouseDown() {
        EnableSpawnAreas();
        theCursor.cursor.gameObject.SetActive(true);
        theCursor.cursor.sprite = myUnitMouse.mySpriteRenderer.sprite;
        theCursor.cursor.gameObject.transform.localScale = myUnitMouse.transform.localScale;
        while (Input.GetMouseButton(0)) {
            yield return null;
        }
        myUnitMouse = null;
        DisableSpawnAreas();
        theCursor.cursor.gameObject.SetActive(false);

    }

    void SpawnUnit()
    {
        float offset = UnityEngine.Random.Range(-2, 2);
        if (canSpawnUnit && myUnitMouse != null && GameController.instance.EnoughResources(myUnitMouse.resourceCost))
        {
            Vector2 spawnPosition = new Vector2(UnitSpawnController.currentSpawnArea.transform.position.x, UnitSpawnController.currentSpawnArea.transform.position.y + offset);

            Instantiate(myUnitMouse, spawnPosition, transform.rotation);
            UseResources(myUnitMouse.resourceCost);
            UnitSpawnController.currentSpawnArea.ReturnToDefaultColor();
            StartCoroutine(GlobalCooldown());
        }

    }
    private IEnumerator GlobalCooldown()
    {
        canSpawnUnit = false;
        yield return new WaitForSeconds(0.25f);
        canSpawnUnit = true;

    }
}

