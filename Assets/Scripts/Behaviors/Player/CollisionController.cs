using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	private float newDeflateRate = .006f;
	private Jump jump;
	private string previousBalloon;
	private float distance;
	private float leftBorder;
	private float rightBorder;
	private Rigidbody2D playerBody;
	public bool gameOver = false;

	void Start () {
		DontDestroyOnLoad (this);
		jump = this.GetComponent<Jump> ();
		playerBody = this.gameObject.GetComponent<Rigidbody2D> ();

		distance = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x;
		rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x;

		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);

	}

	void FixedUpdate () {
		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds () {

		if (transform.position.x + this.renderer.bounds.size.x / 2 >= rightBorder) {
			jump.rightMovementAllowed = false;
		} 
		if (transform.position.x - this.renderer.bounds.size.x / 2 <= leftBorder) {				
			jump.leftMovementAllowed = false;
		} 

		if (rigidbody2D.velocity.y < -3) {
			rigidbody2D.velocity -= new Vector2 (rigidbody2D.velocity.x, .1f);
		}
		if (rigidbody2D.velocity.y < -30) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -30);
		}	
	}

	private void onDeath (Notification Note) {
		this.gameOver = true;
		//foreach (Object obj in GameObject.FindGameObjectsWithTag("platform")) {
		//	Physics.IgnoreCollision(((GameObject)obj).collider2D , GameObject.Find ("player").collider2D);
	}

	public void OnCollisionEnter2D (Collision2D other) {

		if (!gameOver) {

			if (other.gameObject.tag == "floor") {
				jump.setGrounded (true);
				jump.jumpConstant = 1f;
				jump.playerSpeed = 5;
			} else if (other.gameObject.tag == "platform") {

				jump.setGrounded (true);
				jump.jumpConstant = 1f;
				jump.playerSpeed = 5;

				if (other.gameObject.name == "JumpBalloon") {
					jump.jumpConstant = 2.5f;
					previousBalloon = other.gameObject.name;
				} else if (other.gameObject.name == "SpeedBalloon") {
					jump.playerSpeed = 10;
					previousBalloon = other.gameObject.name;
				}
			}

		} 
	}
    
}
