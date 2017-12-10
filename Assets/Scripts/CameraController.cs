using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

    private Camera theCamera;
	void Start () {
        theCamera = GetComponent<Camera>();
        //MoveCameraForward();
    }
	
	// Update is called once per frame
	public void ChangeCameraPosition (Vector2 position) {
        transform.position = position;
    }

    public void MoveCameraForward(int cameraMoveDistance)
    {
        StartCoroutine(MoveCamera(cameraMoveDistance));

    }

    private IEnumerator MoveCamera(int cameraMoveDistance) {
        float i = transform.position.y + cameraMoveDistance;
        while (i >= transform.position.y) {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 30, -10);
            yield return null;
        }

    }
}
