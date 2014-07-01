using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	public float newDeflateRate = .006f;


	void Start () {
		DontDestroyOnLoad (this);

	}
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

		if (rigidbody2D.velocity.y < -3) {
			rigidbody2D.velocity -= new Vector2 (rigidbody2D.velocity.x, .1f);
		}
		if (rigidbody2D.velocity.y < -30) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -30);
		}	
	}
}
