using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : Singleton<PauseMenuController> {

	public bool paused { get; private set; }
    public GameObject menu;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused)
            {
                UnPauseGame();
            }
            else {
                PauseGame();
            }
        }
	}

    private void PauseGame() {
        paused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    private void UnPauseGame()
    {
        paused = false;
        menu.SetActive(false);

        Time.timeScale = 1;
    }

    public void RestartGame() { }
    public void Quit() {
        Application.Quit();
    }
}
