using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float playerSpeed = 5;
    private bool playerGrounded = true;
    private int playerJumpHeight = 500;


   
    public void setGrounded(bool ground) {
        playerGrounded = ground;
    }

    public void playerJump() {
		if (isGrounded()) {
            rigidbody2D.AddForce(new Vector2(0, playerJumpHeight));
            this.GetComponent<AnimationController>().jumpAnimation();
            setGrounded(false);
        }
    }

    public void xAxisMvmtRight() {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        this.GetComponent<AnimationController>().facingLeft(false);
    }

    public void xAxisMvmtLeft() {
        transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
        this.GetComponent<AnimationController>().facingLeft(true);
    }

	public bool isGrounded() {
		
		float playerSize = this.renderer.bounds.size.y;
		Vector3 position1 = transform.position;
		Vector3 position2 = transform.position;
		position2.x = position2.x + playerSize;
		position2.y = position2.y - playerSize/2;
		
		Collider2D[] hits = Physics2D.OverlapAreaAll(new Vector2(position1.x, position1.y), new Vector2(position2.x, position2.y));
		Notification collision = new Notification(NotificationType.OnBalloonPlayerCollision, "Balloon Collided!");
		
		int i = 0;
		while (i < hits.Length)  {
			Collider2D hit = hits[i];
			if (hit != null) {
				if (hit.tag == "platform") {
					NotificationCenter.defaultCenter.postNotification(collision);
					Debug.Log ("now grounded is true");
					return true;
				}
			}
			i++;
		}
		return false;
	}
}
