using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class StageManager : Singleton<StageManager> {

    private AudioSource myAudioSource;
    [SerializeField]
    private AudioClip soundWhenStageCompleted;
    [SerializeField]
    private AudioClip soundOnVictory;
    public const int howMuchCameraMoves = 80;

    public Stage[] stages;
    public int currentStage = 0;

    void Start () {
        myAudioSource = GetComponent<AudioSource>();
        StartGame();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Y)) {
            EnableNewStage();

        }
    }

    public void ChangeCameraPosition() {
        CameraController.Instance.MoveCameraForward(howMuchCameraMoves);
    }

    public void ChangeSpawnArea()
    {
        foreach (UnitSpawnController spawn in UnitSpawnController.spawnAreas) {
            spawn.transform.position = new Vector2(spawn.transform.position.x, spawn.transform.position.y + howMuchCameraMoves);
        }
        
    }

    public void StartGame() {
        SetGoalCount();
    }

    public void EnableNewStage() {
        GameController.Instance.RemoveOldUnits();
        //DisableStage();
        currentStage++;
        if (stages.Length > currentStage)
        {
            stages[currentStage].EnableStage();
            SetGoalCount();
            PlaySoundWhenStageCompleted();
            ChangeSpawnArea();
            ChangeCameraPosition();
        }
        else
        {
            PlaySoundOnVictoryCompleted();
            print("Game over!");
            WinGameUI.Instance.WinGame();
            Time.timeScale = 0;
        }
        //ResetGoal count
        //Change SpawnArea positions
        //Enable new buildings



    }

    public void EnableStage() {
        if (stages.Length > currentStage)
        {
            stages[currentStage].EnableStage();
            SetGoalCount();

            ChangeSpawnArea();
            ChangeCameraPosition();
        }
        else {
            print("Game over!");
            WinGameUI.Instance.WinGame();
            Time.timeScale = 0;
        }
    }
    public void DisableStage() {
        stages[currentStage].DisableStage();
    }


    public void SetGoalCount()
    {
        //GameController.Instance.goalCount = (stages[currentStage].enemyBases).Length;
        GameController.Instance.goalCount = stages[currentStage].goals;

    }

    public void PlaySoundWhenStageCompleted()
    {
        myAudioSource.PlayOneShot(soundWhenStageCompleted, 0.3f);

    }
    public void PlaySoundOnVictoryCompleted()
    {
        myAudioSource.PlayOneShot(soundOnVictory, 0.3f);

    }
}
[System.Serializable]
public class Stage {
    //public EnemyBaseController[] enemyBases;
    public int goals;
    public GameObject stage;


    public void DisableStage() {
        stage.SetActive(false);
    }
    public void EnableStage()
    {
        stage.SetActive(true);
    }


}
