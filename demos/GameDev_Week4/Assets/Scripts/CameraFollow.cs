using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Transform topRightBounds;
    public Transform bottomLeftBounds;

    public Vector2 offset;

    // Update is called once per frame
    void Update () {
        float xPos = transform.position.x;
        float yPos = target.position.y;

        if (target.position.x < bottomLeftBounds.position.x) {
            xPos += target.position.x - bottomLeftBounds.position.x;
        } else if (target.position.x > topRightBounds.position.x) {
            xPos += target.position.x - topRightBounds.position.x;
        }

        Vector3 newPos = new Vector3(xPos + offset.x, yPos + offset.y, transform.position.z);
        transform.position = newPos;
	}
}
