using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBase : MonoBehaviour {

    private Health myHealth;

    public int resourcesToGive = 0;

	// Use this for initialization
	void Start () {
        myHealth = GetComponent<Health>();
        myHealth.tookDamage += GiveResources;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GiveResources() {
        GameController.instance.AddResources(resourcesToGive);
    }


}
