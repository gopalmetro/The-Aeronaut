using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Vector2 startPos = new Vector2 (0.028801f, 0);
	public bool isCenter = false;
	public char id;
	private int index = 0;
	private int height = 0;
	private GameObject Player;

	public void Awake () {
		Player = GameObject.Find ("player");
		this.transform.localScale = new Vector3 (this.transform.localScale.x, this.transform.localScale.y * 1.5f, this.transform.localScale.z);
		this.GetComponent<SpriteRenderer> ().sortingOrder = -1000;
	}

	public void setIndex (int ind) {
		this.index = ind;
	}

	public void setHeight (int h) {
		height = h;
		this.transform.position = new Vector3 (this.transform.position.x, h * getRendererHeight (), 10); //anchor at 0.5
	}

	public int getHeight () {
		return height;
	}

	public int getIndex () {
		return this.index;
	}

	public void setID (char id) {
		this.id = id;
	}

	public void setSprite (Sprite newSprite) {
		this.GetComponent<SpriteRenderer> ().sprite = newSprite;
	}

	public float getRendererHeight () {
		return this.renderer.bounds.size.y;
	}

	public void setColliderBounds () {
		this.GetComponent<BoxCollider2D> ().size = new Vector2 (this.GetComponent<SpriteRenderer> ().sprite.bounds.size.x,
            this.GetComponent<SpriteRenderer> ().sprite.bounds.size.y - Player.renderer.bounds.size.y);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!isCenter && other.gameObject.tag == "Player") {
			try {
				try {
					BackgroundNotification note = new BackgroundNotification (NotificationType.BackgroundObjectNotification, this.gameObject);
					NotificationCenter.defaultCenter.postNotification (note);
					isCenter = true;
				} catch (MissingReferenceException e) {//unity
				}//Debug.Log ("BackgroundController - onNotification: caught Exception from stale notification ");}
			} catch (System.NullReferenceException) {//ios
			}//Debug.Log ("BackgroundController - onNotification: caught Exception from stale notification ");}
		}
	}

	void OnTriggerExit2D (Collider2D other) {    
	}
}
