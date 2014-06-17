using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    
    
    private Animator animator;
    private bool isLeft = true;

    void Start() {
        animator = this.GetComponent<Animator>();
    }

    void Update() {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("jumpleft") && this.GetComponent<Jump>().isGrounded()) {
            animator.SetInteger("Direction", 0);
        }
        if (this.rigidbody2D.velocity.x == 0 && this.GetComponent<Jump>().isGrounded()) {
            animator.SetInteger("Direction", 0);
        }
    }
    public void jumpAnimation() {
        animator.SetInteger("Direction", 1);
    }

    public void facingRight(){
        //animator.SetInteger("Direction", 2);
    }


}
