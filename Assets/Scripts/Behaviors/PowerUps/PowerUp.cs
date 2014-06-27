using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public Vector2 speed;
    public Vector2 direction;
    protected Vector2 movement;

    void Start() {
        speed = new Vector2(0, 1);
        direction = new Vector2(0, -1);
    }

    void OnTriggerEnter2D(Collider2D other) {

        Notification powerUp = new Notification(NotificationType.OnPowerUp, "Powerup");
        Notification achievement = new Notification(NotificationType.OnAchievableEvent, "Powerup Picked Up!");

        if (other.gameObject.tag == "Player") {
            //send Notification
            NotificationCenter.defaultCenter.postNotification(powerUp);
            NotificationCenter.defaultCenter.postNotification(achievement);
            Destroy();
        }


    }

    void Update() {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    protected void FixedUpdate() {
        rigidbody2D.velocity = movement;
    }

    public void Destroy() {
		this.gameObject.SetActive(false);
    }
}
