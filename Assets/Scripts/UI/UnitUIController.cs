using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitUIController : MonoBehaviour {


    public static UnitUIController currentUnitController;
    public UnitController unitPlacing;

    public Image buttonImage;

    void Start () {
        buttonImage.sprite = unitPlacing.GetComponent<SpriteRenderer>().sprite;

    }


    public void onMouseEnter() {

        GameController.Instance.myUnitMouse = unitPlacing;
        buttonImage.color = new Color(1, 1, 1, 0.8f);



    }
    public void onMouseExit()
    {
        buttonImage.color = Color.white;
    }

}
