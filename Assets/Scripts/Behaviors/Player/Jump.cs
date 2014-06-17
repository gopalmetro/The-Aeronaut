using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float playerSpeed = 5;
    public bool isJumping = false;
    private bool playerGrounded = true;
    private int playerJumpHeight = 500;



    public bool isGrounded() {
        return playerGrounded;
    }

    public void setGrounded(bool ground) {
        playerGrounded = ground;
    }
    public void playerJump() {
        if (playerGrounded && !isJumping) {
            rigidbody2D.AddForce(new Vector2(0, playerJumpHeight));
            this.GetComponent<AnimationController>().jumpAnimation();
            isJumping = true;
        }
    }

    public void xAxisMvmtRight() {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        if (playerGrounded) {
            //this.GetComponent<AnimationController>().facingRight();
        }
    }

    public void xAxisMvmtLeft() {
        transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
        if (playerGrounded) {
            //this.GetComponent<AnimationController>().facingLeft();
        }
    }
}
