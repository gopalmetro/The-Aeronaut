using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public bool gameOver = false;
	private float currentY;
	
	void Start () {
		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);
	}
	
	void Update () {

		if (!gameOver) {
			this.keyboardControls ();
			this.iOSControls ();
			this.mouseControls ();
		}
	}

	void mouseControls () {
		var screenPoint = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown (0) && this.GetComponent<Jump> ().isGrounded ()) { 
			this.GetComponent<Jump> ().playerJump ();
		}
		//if (screenPoint.origin.x < transform.position.x) { this.GetComponent<Jump>().xAxisMvmtLeft(); }
		//if (screenPoint.origin.x > transform.position.x) { this.GetComponent<Jump>().xAxisMvmtRight(); }
	}

	void iOSControls () {
		foreach (Touch touch in Input.touches) {
			var screenPoint = Camera.main.ScreenPointToRay (touch.position);
			if (touch.phase == TouchPhase.Began) { 
				this.GetComponent<Jump> ().playerJump ();
			}
			if (screenPoint.origin.x < transform.position.x) {
				this.GetComponent<Jump> ().xAxisMvmtLeft ();
			}
			if (screenPoint.origin.x > transform.position.x) {
				this.GetComponent<Jump> ().xAxisMvmtRight ();
			}
		}

		Vector3 dir = Vector3.zero;
		float deltaX = dir.x = Input.acceleration.x;
		float deltaY = dir.y = -Input.acceleration.y;
		
		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}

		dir.y = 0;
		
		dir *= Time.deltaTime;
		Vector3 newDir = transform.position;
		newDir.x += 5 * dir.x * this.GetComponent<Jump> ().playerSpeed;
		newDir.y = transform.position.y;
		transform.position = newDir;



		float difference = 1000 * Mathf.Abs (deltaY - this.currentY);


		if (difference > 150) {
			this.GetComponent<Jump> ().playerJump ();
			Debug.Log (difference);
		} 

		this.currentY = deltaY;
	}

	void keyboardControls () {
		if (Input.GetButtonDown ("Jump")) { 
			this.GetComponent<Jump> ().playerJump ();
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
