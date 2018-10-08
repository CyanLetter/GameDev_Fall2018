using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D body;
    public float moveSpeed = 5f;
    int itemsCollected = 0;
    int itemsToWin = 5;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        //Vector2 pos = new Vector2(transform.position.x + horizontalInput, transform.position.y + verticalInput);
        //body.MovePosition(pos);

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        body.AddForce(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable")) {
            collision.gameObject.SetActive(false);

            itemsCollected += 1;
            print(itemsCollected);
            if (scoreText != null) {
                scoreText.text = itemsCollected.ToString();
            }

            if (itemsCollected >= itemsToWin) {
                OnWin();
            }

        }

    }

    void OnWin () {
        print("Success!");

        if (scoreText != null)
        {
            scoreText.text = "You win!";
        }
    }
}
