using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float playerSpeed = 5;
    public float jumpConstant = 1;
	private bool playerGrounded = true;
	private int playerJumpHeight = 500;
   
	public void setGrounded (bool ground) {
		playerGrounded = ground;
	}

	public void playerJump () {
        if (isGrounded()) {
            rigidbody2D.AddForce(new Vector2(0, playerJumpHeight * jumpConstant));
            setGrounded(false);
        }
        else {
            setGrounded(false);
        }
	}

	public void xAxisMvmtRight () {
		transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		this.GetComponent<AnimationController> ().faceRight ();
	}

	public void xAxisMvmtLeft () {
		transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
		this.GetComponent<AnimationController> ().faceLeft ();
	}

	public void rest () {
		this.GetComponent<AnimationController> ().faceCenter ();
	}

    public bool isGrounded() {
        return playerGrounded;
    }
}