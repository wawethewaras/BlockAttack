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




    void Start () {
        currentHealth = maxHealth;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = mySpriteRenderer.material;
    }

    public void ReduceHealth(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
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
