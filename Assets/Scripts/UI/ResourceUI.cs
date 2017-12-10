using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

    public TextMeshProUGUI uiText;
     

    void Start () {
        uiText.text = "Resources: " + GameController.Instance.resouces;

        GameController.Instance.resourcesAltered += UpdateResources;

    }
	public void UpdateResources () {
        uiText.text = "Resources: " + GameController.Instance.resouces;
    }
}
