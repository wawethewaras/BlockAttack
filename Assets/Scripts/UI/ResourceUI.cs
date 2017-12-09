using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

    public Text uiText;
     

    void Start () {
        uiText.text = "Resources: " + GameController.Instance.resouces;

        GameController.Instance.resourcesAltered += UpdateResources;

    }
	public void UpdateResources () {
        uiText.text = "Resources: " + GameController.Instance.resouces;
    }
}
