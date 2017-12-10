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
    public event Action died;
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
    public void Died()
    {
        if (died != null)
        {
            died();
        }
    }
    public void ReduceHealth(int damage) {
        TookDamage();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Died();
            if (destroyWhen0Health)
            {
                Destroy(gameObject);

            }
        }
        else {
            StartCoroutine(ChangeMaterial());
        }
    }

    private IEnumerator ChangeMaterial() {
        mySpriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.material = defaultMaterial;
    }
}
