using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : Singleton<GameController> {
    public int goalCount = 0;

    public int resouces;

    public UnitController[] unitPlayerHas;

    private int smallestUnitCost;

    public UnitController myUnitMouse { set; get; }

    private UnitUIController currentUnitUIController;
    private bool canSpawnUnit = true;
    public bool mouseUp = true;


    //public static int numberOfUnitInField = 0;
    public List<UnitController> unitInField = new List<UnitController>();

    public SpawnAreas spawnAreas;

    public event Action resourcesAltered;

    public void ResourcesAltered() {
        if (resourcesAltered != null) {
            resourcesAltered();
        }
    }

    private CursorController theCursor;

    void Start () {
        theCursor = CursorController.Instance;
        smallestUnitCost = GetSmallestUnitCost();
        DisableSpawnAreas();
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && myUnitMouse != null && GameController.instance.EnoughResources(myUnitMouse.resourceCost) && PauseMenuController.Instance.paused == false) {
            MouseHeldDown();
        }
        if (Input.GetMouseButtonUp(0) && UnitSpawnController.currentSpawnArea != null && PauseMenuController.Instance.paused == false)
        {
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

        if (resouces < smallestUnitCost) {
            StartCoroutine(EndGameIfUnitsDie());
        }
    }
    public void AddResources(int amount) {
        resouces += amount;
        ResourcesAltered();
    }

    public void EnableSpawnAreas() {
        //foreach(UnitSpawnController game in UnitSpawnController.spawnAreas) {
        //    game.gameObject.SetActive(true);
        //}
        spawnAreas.EnableSpawns(StageManager.Instance.GetCurrentStage().goals);
    }
    public void DisableSpawnAreas() {
        //foreach (UnitSpawnController game in UnitSpawnController.spawnAreas)
        //{
        //    game.gameObject.SetActive(false);
        //}
        spawnAreas.DisableSpawns();
    }

    public int GetSmallestUnitCost() {
        //Sets base cost to high
        int cost = 10000;
        for (int i = 0; i < unitPlayerHas.Length; i++) {
            if (cost > unitPlayerHas[i].resourceCost) {
                cost = unitPlayerHas[i].resourceCost;
            }
        }
        return cost;
    }


    public void MouseHeldDown()
    {
        StartCoroutine(WhileMouseDown());
    }

    private IEnumerator WhileMouseDown() {
        EnableSpawnAreas();
        mouseUp = false;
        theCursor.cursor.gameObject.SetActive(true);
        theCursor.cursor.sprite = myUnitMouse.mySpriteRenderer.sprite;
        theCursor.cursor.gameObject.transform.localScale = myUnitMouse.transform.localScale;
        while (Input.GetMouseButton(0) && !PauseMenuController.Instance.paused) {
            yield return null;
        }
        mouseUp = true;
        myUnitMouse = null;
        DisableSpawnAreas();
        theCursor.cursor.gameObject.SetActive(false);

    }

    void SpawnUnit()
    {
        if (canSpawnUnit && myUnitMouse != null && EnoughResources(myUnitMouse.resourceCost))
        {
            float offsetY = UnityEngine.Random.Range(-2, 2);
            float offsetX = UnityEngine.Random.Range(-3.5f,3.5f);
            Vector2 spawnPosition = new Vector2(UnitSpawnController.currentSpawnArea.transform.position.x + offsetX, UnitSpawnController.currentSpawnArea.transform.position.y + offsetY);

            UnitController newUnit = Instantiate(myUnitMouse, spawnPosition, transform.rotation);
            UnitSpawnController.currentSpawnArea.ReturnToDefaultColor();
            StartCoroutine(GlobalCooldown());

            unitInField.Add(newUnit);
            UseResources(myUnitMouse.resourceCost);

        }


    }
    private IEnumerator GlobalCooldown()
    {
        canSpawnUnit = false;
        yield return new WaitForSeconds(0.25f);
        canSpawnUnit = true;

    }

    private IEnumerator EndGameIfUnitsDie()
    {
        while (unitInField.Count > 0) {
            if (resouces >= smallestUnitCost) {
                break;
            }
            yield return null;
        }
        if (resouces < smallestUnitCost)
        {
            Debug.Log("Out of resources! Game over!");
            GameOver();
        }
    }

    public void RemoveOldUnits()
    {
        for (int i = 0; i < unitInField.Count; i++)
        {
            if (unitInField[i] != null) {
                Destroy(unitInField[i].gameObject);
            }
        }
        unitInField.Clear();
    }

    public void GameOver() {
        StageManager.Instance.PlaySoundOnGameOver();
        GameOverUI.Instance.GameOver();
        Time.timeScale = 0;

    }



}

[System.Serializable]
public class SpawnAreas
{
    public UnitSpawnController spawn1;
    public UnitSpawnController spawn2;
    public UnitSpawnController spawn3;

    public void DisableSpawns()
    {
        spawn1.gameObject.SetActive(false);
        spawn2.gameObject.SetActive(false);
        spawn3.gameObject.SetActive(false);

    }
    public void EnableSpawns(int numberOfSpawns)
    {
        if (numberOfSpawns >= 1)
        {
            spawn1.gameObject.SetActive(true);
        }
        if (numberOfSpawns >= 2)
        {
            spawn2.gameObject.SetActive(true);
        }
        if (numberOfSpawns >= 3)
        {
            spawn3.gameObject.SetActive(true);
        }
    }
}

