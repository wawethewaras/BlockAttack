using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour {

    public static List<UnitSpawnController> spawnAreas = new List<UnitSpawnController>();
    public static UnitSpawnController currentSpawnArea;

    private SpriteRenderer myRenderer;

    void Awake () {
        spawnAreas.Add(this);
        myRenderer = GetComponent<SpriteRenderer>();

    }

    void OnMouseEnter()
    {
        myRenderer.color = new Color(0.7f, 0.7f, 0.7f, 0.5f);
        currentSpawnArea = this;
    }

    void OnMouseExit()
    {
        myRenderer.color = Color.white;
        currentSpawnArea = null;
    }

    public void ReturnToDefaultColor() {
        myRenderer.color = Color.white;
    }

}
