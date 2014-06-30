using UnityEngine;
using System.Collections;

public class BalloonAppearance : MonoBehaviour {

	public float deflateRate;
	public Vector2 speed;
	public Vector2 direction;
	public float accel;

	private readonly float KCollisionDeflateRate = 0.006f;
	private Vector3 KOriginalScale;
	private float KNormalDeflateRate;

	void Start () {
		KOriginalScale = this.transform.localScale;
		KNormalDeflateRate = this.deflateRate;
	}

	void Update () {

		if (transform.localScale.x >= 0) {
			Vector3 reduce = new Vector3 (deflateRate, deflateRate, 0);
			transform.localScale -= reduce;
		} else {
			this.Destroy ();
		}

		speed += new Vector2 (0, accel);
		rigidbody2D.velocity = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}


	public void setSprite(Sprite sprite) {
		this.GetComponent<SpriteRenderer>().sprite = sprite;
	}

	public void Destroy () {

		Notification balloonPop = new Notification (NotificationType.BalloonPop);
		NotificationCenter.defaultCenter.postNotification (balloonPop);
	
		this.transform.localScale = KOriginalScale;
		this.deflateRate = KNormalDeflateRate;
		this.gameObject.SetActive (false);
	}
	
	public void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.tag == "floor") {
			Physics2D.IgnoreCollision (this.gameObject.collider2D, other.gameObject.collider2D);
		}

		if (other.gameObject.tag == "Player") {
			this.deflateRate = KCollisionDeflateRate;
		}

		if (other.gameObject.tag == "platform") {
			Physics2D.IgnoreCollision (this.gameObject.collider2D, other.gameObject.collider2D);
		}
	}
	
	public void OnTriggerEnter2D (Collider2D other) {
	}
	
}
