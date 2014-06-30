using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {

    public Texture2D buttonimage;
    public GUISkin GUIskin; 

    void OnGUI() {
        GUI.skin = GUIskin;
        if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 250, buttonimage.width +100, buttonimage.height +100), buttonimage)) {
            Application.LoadLevel("stage1");
        }
    }
}
