using UnityEngine;
using System.Collections;

public class DeathBehavior : MonoBehaviour {

    private GameObject player;
    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        Color textureColor = this.guiTexture.color;
        textureColor.a = 0;
        guiTexture.color = textureColor;
        NotificationCenter.defaultCenter.addListener(onDeath, NotificationType.Death);
	}
	
	// Update is called once per frame
	void Update () {
        Color textureColor = this.guiTexture.color;
        if (player.rigidbody2D.velocity.y  < -15) {
            //textureColor.a = -(player.rigidbody2D.velocity.y) / 60;
            float alpha = Mathf.Lerp(textureColor.a, 1, 0.9f * Time.deltaTime);
            textureColor.a = alpha;
            guiTexture.color = textureColor;
            if (textureColor.a > .6) {
                gameOver = true;
                Notification Death = new Notification(NotificationType.Death);
                NotificationCenter.defaultCenter.postNotification(Death);
            }
            Debug.Log(textureColor.a);
        }
        else if (!gameOver) {
            textureColor.a = 0;
            guiTexture.color = textureColor;
        }
	}

    private void onDeath(Notification Note)  {
        Color textureColor = this.guiTexture.color;
        this.gameOver = true;
        textureColor.a = 1;
        guiTexture.color = textureColor;
    }
}
