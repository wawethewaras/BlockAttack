using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public int resouces;

    public Text uiText;

    public UnitMouse myUnitMouse;

    public GameObject[] spawnAres;

    public bool mouseDown;

    public UnitUIController currentUnitUIController;

    public UnitSpawnController currentSpawnArea;


    public SpriteRenderer cursor;


    void Awake () {
        instance = this;
        uiText.text = "Resources: " + resouces;
        DisableSpawnAreas();
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && myUnitMouse.unitPlacedOnClick != null) {
            MouseHeldDown();
        }
        if (Input.GetMouseButtonUp(0) && currentSpawnArea != null) {
            SpawnUnit();
        }
        cursor.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public bool EnoughResources(int amount) {
        return resouces >= amount;
    }

    public void UseResources(int amount) {
        resouces -= amount;
        uiText.text = "Resources: " + resouces;

    }
    public void AddResources(int amount)
    {
        resouces += amount;
        uiText.text = "Resources: " + resouces;
    }

    public void SetMouseCursor() {

    }


    public void EnableSpawnAreas() {
        foreach(GameObject game in spawnAres) {
            game.SetActive(true);
        }
    }
    public void DisableSpawnAreas()
    {
        foreach (GameObject game in spawnAres)
        {
            game.SetActive(false);
        }
    }

    public void MouseHeldDown()
    {
        StartCoroutine(WhileMouseDown());
    }

    private IEnumerator WhileMouseDown() {
        mouseDown = true;
        EnableSpawnAreas();
        cursor.gameObject.SetActive(true);
        cursor.sprite = myUnitMouse.unitPlacedOnClick.GetComponent<SpriteRenderer>().sprite;
        cursor.gameObject.transform.localScale = myUnitMouse.unitPlacedOnClick.transform.localScale;
        while (Input.GetMouseButton(0)) {
            yield return null;
        }
        myUnitMouse.unitPlacedOnClick = null;
        DisableSpawnAreas();
        mouseDown = false;
        GameController.instance.cursor.gameObject.SetActive(false);

    }
    private bool canSpawnUnit = true;

    void SpawnUnit()
    {
        float offset = Random.Range(-2, 2);
        if (canSpawnUnit && GameController.instance.EnoughResources(5) && GameController.instance.myUnitMouse.unitPlacedOnClick != null)
        {
            Vector2 spawnPosition = new Vector2(currentSpawnArea.transform.position.x, currentSpawnArea.transform.position.y + offset);

            Instantiate(GameController.instance.myUnitMouse.unitPlacedOnClick, spawnPosition, transform.rotation);
            GameController.instance.UseResources(5);
            StartCoroutine(GlobalCooldown());
        }

    }
    private IEnumerator GlobalCooldown()
    {
        canSpawnUnit = false;
        yield return new WaitForSeconds(0.5f);
        canSpawnUnit = true;

    }
}

[System.Serializable]
public class UnitMouse {
    public GameObject unitPlacedOnClick;
}
