using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 flapForce;

    public LevelManager manager;

    Rigidbody2D body;
    Animator anim;

    bool dead = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dead) {
            return;
        }
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            body.AddForce(flapForce, ForceMode2D.Impulse);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score")) {
            manager.AddPoints();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dead && collision.gameObject.CompareTag("Deadly")) {
            Kill();
        }
    }

    void Kill() {
        manager.OnGameOver();
        body.isKinematic = true;
        body.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
