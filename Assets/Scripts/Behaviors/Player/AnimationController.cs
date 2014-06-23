using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    
    
    private Animator animator;
    private bool isLeft = true;

    void Start() {
        animator = this.GetComponent<Animator>();
    }

    void Update() {
        if (this.GetComponent<Jump>().isGrounded()) {
            animator.SetInteger("Direction", 0);
        }
    }

	public void faceCenter() {
		Debug.Log ("CENTER");
		animator.SetInteger ("Direction", 0);
	}


	public void faceLeft() {
		Debug.Log ("LEFT");
		animator.SetInteger ("Direction", 1);
	}
	
	public void faceRight() {
		Debug.Log ("right");
		animator.SetInteger ("Direction", 2);
	}



}
