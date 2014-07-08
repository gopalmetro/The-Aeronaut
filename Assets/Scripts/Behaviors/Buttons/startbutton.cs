using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {

    public Texture2D buttonimage;
    public GUISkin GUIskin; 

    void OnGUI() {
        GUI.skin = GUIskin;
		if (GUI.Button(new Rect(Screen.width*.07f, Screen.height*.72f, buttonimage.width + Screen.width/7, buttonimage.height + Screen.width/7), buttonimage)) {
            Application.LoadLevel("stage1");
        }
    }
}
