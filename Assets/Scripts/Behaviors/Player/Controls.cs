using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public bool gameOver = false;
	private float lastAccelerationY;

	void Start () {
		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);
	}


	void Update () {
		if (!gameOver) {
			this.keyboardControls();
 			this.iOSControls(); 
		}
        }
	
	void iOSControls () {

		foreach (Touch touch in Input.touches) {
			var screenPoint = Camera.main.ScreenPointToRay (touch.position);
			if (touch.phase == TouchPhase.Began) { 
				this.GetComponent<Jump> ().playerJump (1f);
			}
		}

		float accelerametorDelta = Mathf.Abs (-Input.acceleration.y - this.lastAccelerationY);
		if (accelerametorDelta > .15 && this.lastAccelerationY > 0 ) {
			this.GetComponent<Jump> ().playerJump (1.1f);
			Debug.Log (accelerametorDelta);
		}this.lastAccelerationY = -Input.acceleration.y;

		Vector2 input = Vector2.zero;
		input.x = Input.acceleration.x;
		if (input.sqrMagnitude > 1) {input.Normalize ();}
		input *= Time.deltaTime;
		Vector3 lateral = transform.position;
		lateral.x += 5 * input.x * this.GetComponent<Jump>().playerSpeed;
		lateral.y = transform.position.y;
		transform.position = lateral;
	}

	void keyboardControls () {
		if (Input.GetButtonDown ("Jump")) { 
			this.GetComponent<Jump> ().playerJump (1f);
		} else if (Input.GetKey ("right") && Input.GetKey ("left")) {
			this.GetComponent<Jump> ().rest ();
		} else if (Input.GetKey ("left")) {
			this.GetComponent<Jump> ().xAxisMvmtLeft (); 
		} else if (Input.GetKey ("right")) {
			this.GetComponent<Jump> ().xAxisMvmtRight (); 
		} else {
			this.GetComponent<Jump> ().rest ();
		}

	}

	private void onDeath (Notification Note) {
		try {
			try {
				this.gameOver = true;
			} catch (MissingReferenceException e) {//unity
			}
		} catch (System.NullReferenceException) {//ios
		}
	}
}
