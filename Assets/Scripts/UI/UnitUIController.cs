using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUIController : MonoBehaviour {


    public static UnitUIController currentUnitController;
    [HideInInspector]
    public UnitController unitPlacing;

    public Image buttonBG;
    public Image buttonImage;
    public TextMeshProUGUI unitCost;
    void Start () {
        buttonImage.sprite = unitPlacing.mySpriteRenderer.sprite;
        unitCost.text = "" + unitPlacing.resourceCost;
        GameController.Instance.resourcesAltered += ChangeButtonIfNotEnoughResources;
        ChangeButtonIfNotEnoughResources();
    }


    public void ChangeButtonIfNotEnoughResources() {
        if (unitPlacing.resourceCost > GameController.Instance.resouces)
        {
            unitCost.color = Color.red;
            buttonBG.color = Color.grey;
        }
        else {
            unitCost.color = Color.black;
            buttonBG.color = Color.white;
        }
    }

    public void onMouseEnter() {
        if (GameController.Instance.mouseUp) {
            GameController.Instance.myUnitMouse = unitPlacing;
            buttonImage.color = new Color(1, 1, 1, 0.8f);
        }




    }
    public void onMouseExit()
    {
        buttonImage.color = Color.white;
    }

}
