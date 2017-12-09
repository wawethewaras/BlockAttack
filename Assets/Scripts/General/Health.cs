using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    private int currentHealth;
    public int CurrentHealth {
        get {
            return currentHealth;
        }
    }

    public Material damageMaterial;
    private Material defaultMaterial;

    private SpriteRenderer mySpriteRenderer;

    public bool destroyWhen0Health = true;

    public event Action tookDamage;

    void Start () {
        currentHealth = maxHealth;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = mySpriteRenderer.material;
    }

    public void TookDamage() {
        if (tookDamage != null) {
            tookDamage();
        }
    }

    public void ReduceHealth(int damage) {
        TookDamage();
        currentHealth -= damage;
        if (currentHealth <= 0 && destroyWhen0Health) {
            Destroy(gameObject);
        }
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial() {
        mySpriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.material = defaultMaterial;
    }
}
