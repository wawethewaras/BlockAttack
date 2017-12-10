using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void StartGame() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public void QuitGame() {

    }
}
