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
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("jumpright") && this.GetComponent<Jump>().isGrounded())
        {
            animator.SetInteger("Direction", 0);
        }
    }

    public void facingLeft(bool yes) {
        isLeft = yes;
    }
    public void jumpAnimation() {
        Debug.Log(isLeft);
        if (isLeft) {
            animator.SetInteger("Direction", 1);
        }
        else {
            animator.SetInteger("Direction", 2);
        }
    }

    public void facingRight(){
        //animator.SetInteger("Direction", 2);
    }


}
