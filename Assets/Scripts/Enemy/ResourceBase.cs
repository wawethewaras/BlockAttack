using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBase : Building {

    public int resourcesToGive = 0;

	// Use this for initialization
	void Start () {
        myHealth.tookDamage += GiveResources;
    }

    public void GiveResources() {
        GameController.Instance.AddResources(resourcesToGive);
    }


}
