using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float playerSpeed = 5;
	public float jumpConstant = 1;
	public bool rightMovementAllowed = true;
	public bool leftMovementAllowed = true;
	private int playerJumpHeight = 500;
	private bool playerGrounded = true;

	public void setGrounded (bool ground) {
		playerGrounded = ground;
	}

	public void playerJump () {
		if (isGrounded ()) {
			rigidbody2D.AddForce (new Vector2 (0, playerJumpHeight * jumpConstant));
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