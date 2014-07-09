using UnityEngine;
using System.Collections;

public class DeathBehavior : MonoBehaviour {

	private readonly float maxFallTime = 1.5f;
	private float fallTimer;
	private bool dead;
	private GameObject player;

	void Start () {
		player = GameObject.Find ("player");
		fallTimer = maxFallTime;
		dead = false;
		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);
	}

	void Update () {
		if (falling ()) {
			this.setRedAlpha (Mathf.Lerp (this.guiTexture.color.a, 1, 0.9f * Time.deltaTime));
			fallTimer -= Time.deltaTime;
			if (fallTimer <= 0 && !dead) {
				Notification Death = new Notification (NotificationType.Death);
				NotificationCenter.defaultCenter.postNotification (Death);
			}
		} else if (!dead) {
			fallTimer = maxFallTime;
			this.setRedAlpha (0f);
		}
	}

	public void onDeath (Notification notification) {
		try {
			try {
				this.dead = true;
				this.setRedAlpha (1f);
			} catch (MissingReferenceException e) { //works with Unity
			}
		} catch (System.NullReferenceException) {//works with XCode
		}//Debug.Log ("BackgroundController - onNotification: caught Exception from stale notification ");}

	}

	private void setRedAlpha (float alpha) {
		Color temp = this.guiTexture.color;
		temp.a = alpha;
		this.guiTexture.color = temp;
	}

	private bool falling () {
		return player.rigidbody2D.velocity.y < -15;
	}
	
}


