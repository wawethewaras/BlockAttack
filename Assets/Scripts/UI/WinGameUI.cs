using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameUI : Singleton<WinGameUI> {

    public GameObject winGameScreen;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WinGame() {
        winGameScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
