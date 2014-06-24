using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	public float newDeflateRate = .006f;
	private GameObject cam;
	private bool isGrounded = false ;


	void Start () {
		cam = GameObject.Find ("Main Camera");
		DontDestroyOnLoad (this);

	}

	void Update () {
		this.checkForLoss ();
	}

	bool check = true;

	void FixedUpdate () {
		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds () {
		if (transform.position.x >= 10.01) {
			transform.position = new Vector3 (10.01f, transform.position.y, transform.position.z);
		}
		if (transform.position.x < -10) {
			transform.position = new Vector3 (-10, transform.position.y, transform.position.z);
		}

		if (rigidbody2D.velocity.y < -3 && check) {
			rigidbody2D.velocity -= new Vector2 (rigidbody2D.velocity.x, .1f);
		}
		if (rigidbody2D.velocity.y < -30) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -30);
			check = false;
		}
				
	}

	void checkForLoss () {
		if (transform.position.y <= cam.transform.position.y - 10) {
			Application.LoadLevel ("losescreen");
		}
	}
}
