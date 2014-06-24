using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

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

    public void Destroy() {
        this.gameObject.SetActive(false);
    }
}
