using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float playerSpeed = 5;
	private bool playerGrounded = true;
	private int playerJumpHeight = 500;
   
	public void setGrounded (bool ground) {
		playerGrounded = ground;
	}

	public void playerJump () {
        if (isGrounded()) {
            rigidbody2D.AddForce(new Vector2(0, playerJumpHeight));
            setGrounded(false);
        }
        else {
            setGrounded(false);
        }
	}

	public void xAxisMvmtRight () {
		transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		this.GetComponent<AnimationController> ().faceRight ();
	}

	public void xAxisMvmtLeft () {
		transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
		this.GetComponent<AnimationController> ().faceLeft ();
	}

	public void rest () {
		this.GetComponent<AnimationController> ().faceCenter ();
	}

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platform") {
            setGrounded(true);
        }
    }

    public bool isGrounded() {
        return playerGrounded;
    }
}


/*public bool isGrounded () {
		
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
					return true;
				}
			}
			i++;
		}
		return false;
	}

*/