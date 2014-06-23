using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float playerSpeed = 5;
    private bool playerGrounded = true;
    private int playerJumpHeight = 500;



    public bool isGrounded() {
        return playerGrounded;
    }

    public void setGrounded(bool ground) {
        playerGrounded = ground;
    }
    public void playerJump() {
        if (playerGrounded) {
            rigidbody2D.AddForce(new Vector2(0, playerJumpHeight));
            this.GetComponent<AnimationController>().jumpAnimation();
            setGrounded(false);
        }
    }

    public void xAxisMvmtRight() {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        this.GetComponent<AnimationController>().facingLeft(false);
    }

    public void xAxisMvmtLeft() {
        transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
        this.GetComponent<AnimationController>().facingLeft(true);
    }
}
