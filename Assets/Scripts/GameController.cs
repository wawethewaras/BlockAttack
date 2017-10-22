using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public int resouces;

    public Text uiText;

	void Awake () {
        instance = this;
        uiText.text = "Resources: " + resouces;
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
}
