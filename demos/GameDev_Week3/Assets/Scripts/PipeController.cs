using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

    public float speed = -5f;

    public float despawnPoint = -30f;

	
	// Update is called once per frame
	void Update () {
        float moveDistance = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);

        if (transform.position.x < despawnPoint) {
            Destroy(gameObject);
        }
	}
}
