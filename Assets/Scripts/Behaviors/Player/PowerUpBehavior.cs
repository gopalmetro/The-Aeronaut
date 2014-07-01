using UnityEngine;
using System.Collections;

public class PowerUpBehavior : MonoBehaviour {

	int jumpPowerUpHeight = 750;

	void Start () {
		NotificationCenter.defaultCenter.addListener (powerupActivate, NotificationType.OnPowerUp);
	}
	
	public void powerupActivate (Notification note) {
		rigidbody2D.AddForce (new Vector2 (0, jumpPowerUpHeight));
	}
}
