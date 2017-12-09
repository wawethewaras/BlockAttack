using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreatingUI : MonoBehaviour {

    public UnitUIController unitButton;

    void Start() {
        CreateUnits();
    }

    public void CreateUnits() {

        UnitController[] unitPlayerHas = GameController.Instance.unitPlayerHas;
        int startPositionOfButtons = 100 + unitPlayerHas.Length/2 * -200;
        for (int i = 0; i < unitPlayerHas.Length; i++) {
            UnitUIController unitButtonPrefab = Instantiate(unitButton, transform);
            unitButtonPrefab.unitPlacing = unitPlayerHas[i];
            RectTransform rect = unitButtonPrefab.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(startPositionOfButtons + i*200, 0);
        }
    }

}
