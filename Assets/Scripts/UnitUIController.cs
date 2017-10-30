using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitUIController : MonoBehaviour {


    public static UnitUIController currentUnitController;
    public GameObject unitPlacing;
    public static bool unitPlacingEnabled = false;

    public Image buttonImage;

    void Start () {
        buttonImage.sprite = unitPlacing.GetComponent<SpriteRenderer>().sprite;

    }


    public void onMouseEnter()
    {
        GameController.instance.myUnitMouse.unitPlacedOnClick = unitPlacing;

        buttonImage.color = new Color(1, 1, 1, 0.8f);
        //GameController.instance.EnableSpawnAreas();
    }
    public void onMouseExit()
    {
        buttonImage.color = Color.white;
        //GameController.instance.myUnitMouse.unitPlacedOnClick = null;
    }

    public void PlaceUnit()
    {
        //if (unitPlacingEnabled && currentUnitController == this)
        //{

        //    unitPlacingEnabled = false;
        //    GameController.instance.myUnitMouse.unitPlacedOnClick = null;
        //    GameController.instance.DisableSpawnAreas();
        //    buttonImage.color = Color.white;

        //}
        //else if (unitPlacingEnabled && currentUnitController != this)
        //{
        //    currentUnitController.buttonImage.color = Color.white;
        //    currentUnitController = this;
        //    GameController.instance.myUnitMouse.unitPlacedOnClick = unitPlacing;

        //    buttonImage.color = Color.black;
        //}
        //else {
            //GameController.instance.myUnitMouse.unitPlacedOnClick = unitPlacing;
            //unitPlacingEnabled = true;
            //buttonImage.color = Color.black;
            //currentUnitController = this;
            //GameController.instance.EnableSpawnAreas();
            //GameController.instance.MouseHeldDown();
        //}
    }
}
