using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int bulletSpeed;
    public Direction myDirection = Direction.Up;

    private Vector2 direction;

    public enum Direction {
        Up,
        Down
    }


    void Update() {
        if (myDirection == Direction.Up) {
            direction = Vector2.up;

        }
        else {
            direction = Vector2.down;
        }

        if (PauseMenuController.Instance.paused == false) {
            transform.Translate(direction);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //void OnTriggerEnter2D(Collider2D other) {
    //    if (other.tag == "Bounds") {
    //        Destroy(gameObject);
    //    }
    //}


}
