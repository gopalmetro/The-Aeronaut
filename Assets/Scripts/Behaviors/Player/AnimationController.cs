using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    
	private Animator animator;

	void Start () {
		animator = this.GetComponent<Animator> ();
	}

	public void faceCenter () {
		animator.SetInteger ("Direction", 0);
	}

	public void faceLeft () {
		animator.SetInteger ("Direction", 1);
	}
	
	public void faceRight () {
		animator.SetInteger ("Direction", 2);
	}



}
