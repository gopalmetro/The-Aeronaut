using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {


    bool firstTimeVisible = true;

    void Update() {
        if (!this.renderer.IsVisibleFrom(Camera.main)) {
            firstTimeVisible = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "platform") {
            Physics2D.IgnoreCollision(other.gameObject.collider2D, this.gameObject.collider2D);
        }
        if (other.gameObject.tag == "Player" && !firstTimeVisible) {
            Notification Death = new Notification(NotificationType.Death);
            NotificationCenter.defaultCenter.postNotification(Death);
        }
    }
}
