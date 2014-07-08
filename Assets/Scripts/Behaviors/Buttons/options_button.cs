using UnityEngine;
using System.Collections;

public class options_button : MonoBehaviour {

    public Texture2D optionsimage;
    public GUISkin GUIskin = null;

    void OnGUI() {
        GUI.skin = GUIskin;
		if (GUI.Button(new Rect(Screen.width*.57f, Screen.height*.72f, optionsimage.width + Screen.width/7, optionsimage.height + Screen.width/7), optionsimage)) {
            Application.LoadLevel("settingsscreen");
        }
    }
}
