﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    protected Health myHealth;


    // Use this for initialization
    public  virtual void Awake () {
        myHealth = GetComponent<Health>();
        myHealth.died += Destroyed;
    }


    public virtual void Destroyed()
    {
        gameObject.SetActive(false);
    }

}
