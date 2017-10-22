using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {

    public LayerMask collisionLayerMask;
    public int damageToGive;

    public bool destroyAfterContact = false;

    void Start () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (canDoDamage(other))
        {
            other.GetComponent<Health>().ReduceHealth(damageToGive);
            if (destroyAfterContact) {
                Destroy(gameObject);
            }
        }
    }

    private bool canDoDamage(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & collisionLayerMask) != 0 && other.GetComponent<Health>() != null)
        {
            return true;
        }
        return false;
    }

}
