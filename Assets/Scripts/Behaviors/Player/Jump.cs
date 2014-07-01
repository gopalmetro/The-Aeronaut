using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float playerSpeed = 5;
	private bool playerGrounded = true;
	private int playerJumpHeight = 500;
    private float jumpConstant = 1;
    private int balloonSpeedCount = 0;
   
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

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platform") {
            setGrounded(true);
            jumpConstant = 1f;
            playerSpeed = 5;
            balloonPowerUps(other);
        }
    }

    public void balloonPowerUps(Collision2D other) {
        if (other.gameObject.name == "JumpBalloon") {
            this.rigidbody2D.velocity += new Vector2(0, 10);
            jumpConstant = 2.5f;
        }

        if (other.gameObject.name == "SpeedBalloon") {
            playerSpeed = 10;
            //we can implement these power ups to last through x seconds of time
        }
    }

    public bool isGrounded() {
        return playerGrounded;
    }
}