using UnityEngine;
using System.Collections;

public class DeathBehavior : MonoBehaviour {

	private GameObject player;
	private bool gameOver = false;
	private float deathTimer = 1.5f;
	private float originalDeathTimer;

	// Use this for initialization
	void Start () {
		originalDeathTimer = deathTimer;
		player = GameObject.Find ("player");
		Color textureColor = this.guiTexture.color;
		textureColor.a = 0;
		guiTexture.color = textureColor;
		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);
	}
	
	// Update is called once per frame
	void Update () {
		Color textureColor = this.guiTexture.color;
		if (player.rigidbody2D.velocity.y < -15) {
			deathTimer -= Time.deltaTime;
			float alpha = Mathf.Lerp (textureColor.a, 1, 0.9f * Time.deltaTime);
			textureColor.a = alpha;
			guiTexture.color = textureColor;
			if (deathTimer <= 0) {
				gameOver = true;
				Notification Death = new Notification (NotificationType.Death);
				NotificationCenter.defaultCenter.postNotification (Death);
			}
		} else if (!gameOver) {
			deathTimer = originalDeathTimer;
			textureColor.a = 0;
			guiTexture.color = textureColor;
		}

	}

	private void onDeath (Notification Note) {
		try {
			Color textureColor = this.guiTexture.color;
			this.gameOver = true;
			textureColor.a = 1;
			guiTexture.color = textureColor;
		} catch (MissingReferenceException e) {
			//stale notification
		}
	}
}
