using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {

    public Texture2D buttonimage;
    public GUISkin GUIskin; 


    void OnGUI() {
        GUI.skin = GUIskin;
		float constant = buttonimage.height + Screen.width / 7;
		if (GUI.Button(new Rect(Screen.width*.5f - constant, Screen.height*.73f, buttonimage.width + Screen.width/7, buttonimage.height + Screen.width/7), buttonimage)) {
            Application.LoadLevel("stage1");
        }
    }
}
