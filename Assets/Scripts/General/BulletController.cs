using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int bulletSpeed;
    public Direction myDirection = Direction.Up;

    public enum Direction {
        Up,
        Down
    }


    void Update() {
        if (myDirection == Direction.Up) {
            transform.Translate(Vector2.up);

        }
        else {
            transform.Translate(Vector2.down);
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bounds") {
            Destroy(gameObject);
        }
    }


}
