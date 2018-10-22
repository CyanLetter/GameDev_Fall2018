
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Controls")]
	public string XAxis = "Horizontal";
	public string YAxis = "Vertical";
	public string JumpButton = "Jump";

	[Header("Moving")]
	public float runSpeed = 15;

	[Header("Jumping")]
	public float jumpSpeed = 25;


	
	Rigidbody2D body;

	public bool isGrounded = true;
    Quaternion flippedRotation = Quaternion.Euler(0, 180, 0);

	void Start () {
        body = GetComponent<Rigidbody2D>();
    }


	void FixedUpdate () {
		// control inputs
		float x = Input.GetAxis(XAxis);
		float y = Input.GetAxis(YAxis);

		// Check for jump input
		if (Input.GetButtonDown(JumpButton) && isGrounded) {
            // set a grounded flag, so that we cannot double jump
            isGrounded = false;

            // set y velocity directly
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
		}
		
        // check for movement input
		if (!Mathf.Approximately(x, 0f)) {
			// walk or run
            // note: if you don't want to deal with adding forces, you can set the X velocity directy,
            // the same way we are setting Y velocity
            body.AddForce(new Vector2(runSpeed * x, 0f));
        }

		// flip art left or right based on direction
		if (x > 0)
			transform.localRotation = Quaternion.identity;
		else if (x < 0)
			transform.localRotation = flippedRotation;
	}

	 void OnTriggerEnter2D(Collider2D other)
	 {
        // see if we are touching the ground, and if we are moving downwards
	 	if(other.gameObject.CompareTag("Ground") && body.velocity.y <= 0) {
	 		isGrounded = true;
	 	}
	 }
   
}