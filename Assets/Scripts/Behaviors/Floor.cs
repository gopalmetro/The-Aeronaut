using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    bool isVisible = true;
    void Update() {
        if (!this.renderer.IsVisibleFrom(Camera.main)) {
            isVisible = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platform") {
            Physics2D.IgnoreCollision(other.gameObject.collider2D, this.gameObject.collider2D);
        }
        if (other.gameObject.tag == "Player" && !isVisible)
        {
            Application.LoadLevel("losescreen");
        }
    }
}
