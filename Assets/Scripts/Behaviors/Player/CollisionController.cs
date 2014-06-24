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
		checkIfOnBalloon ();

		this.checkForLoss ();
	}

	bool check = true;

	void FixedUpdate () {
		checkIfOutOfBounds ();
	}

	void checkIfOnBalloon () {

		float playerSize = this.renderer.bounds.size.y;
		Vector3 position1 = transform.position;
		Vector3 position2 = transform.position;

		position1.x = position1.x - playerSize;
		position1.y = position1.y + playerSize / 2;
		
		position2.x = position2.x + playerSize;
		position2.y = position2.y - playerSize / 2;

		Collider2D[] hits = Physics2D.OverlapAreaAll (new Vector2 (position1.x, position1.y), new Vector2 (position2.x, position2.y));
		
		int i = 0;
		while (i < hits.Length) {
			Collider2D hit = hits [i];
			if (hit != null) {
				if (hit.tag == "platform") {
					isGrounded = true;
					return;
				}
			}
			i++;
		}
		isGrounded = false;

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
