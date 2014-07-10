using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float playerSpeed = 5;
	public float jumpConstant = 1;
	public bool rightMovementAllowed = true;
	public bool leftMovementAllowed = true;
	private int playerJumpHeight = 10;
	private bool playerGrounded = true;
	public Vector2 balloonVelocity;

	void Start () {
		balloonVelocity = Vector2.zero;
	}

	public void setGrounded (bool ground) {
		playerGrounded = ground;
	}

	public void playerJump (float jumpMultiple) {
		if (isGrounded ()) {
			playerGrounded = false;
			rigidbody2D.velocity = new Vector2 (0, balloonVelocity.y + (jumpMultiple*playerJumpHeight * jumpConstant));

		} else {
		}
		setGrounded (false);
	}

	public void xAxisMvmtRight () {
		if (rightMovementAllowed) {
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
			this.GetComponent<AnimationController> ().faceRight ();
			leftMovementAllowed = true;
		}
	}

	public void xAxisMvmtLeft () {
		if (leftMovementAllowed) {
			transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
			this.GetComponent<AnimationController> ().faceLeft ();
			rightMovementAllowed = true;
		}
	}

	public void rest () {
		this.GetComponent<AnimationController> ().faceCenter ();
	}

	public bool isGrounded () {
		return playerGrounded;
	}
}