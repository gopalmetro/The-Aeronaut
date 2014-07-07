using UnityEngine;
using System.Collections;

public class restart_button : MonoBehaviour {

    private bool gameOver = false;
    void Start() {
        NotificationCenter.defaultCenter.addListener(onDeath, NotificationType.Death);
    }

    
    void OnGUI() {
        if (gameOver && GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Restart!")) {
            Application.LoadLevel("stage1");
        }
    }

    private void onDeath(Notification Note) {
        this.gameOver = true;
    }
}
