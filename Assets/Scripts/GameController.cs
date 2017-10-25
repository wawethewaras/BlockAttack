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

    void Awake () {
        instance = this;
        uiText.text = "Resources: " + resouces;
        DisableSpawnAreas();
    }
	
	void Update () {
		
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
}

[System.Serializable]
public class UnitMouse {
    public GameObject unitPlacedOnClick;
}
