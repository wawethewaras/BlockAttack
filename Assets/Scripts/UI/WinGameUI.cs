using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameUI : Singleton<WinGameUI> {

    public Text winGameText;
    public Text healthStatus;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WinGame() {
        winGameText.gameObject.SetActive(true);
    }
}
