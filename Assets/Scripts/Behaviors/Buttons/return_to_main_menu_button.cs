using UnityEngine;
using System.Collections;

public class return_to_main_menu_button : MonoBehaviour {

	public Texture2D optionsimage;
    public GUISkin GUIskin = null;

    void OnGUI() {
        GUI.skin = GUIskin;
        if (GUI.Button(new Rect(Screen.width*.5f - optionsimage.width/3, Screen.height*.7f, optionsimage.width - optionsimage.width / 3,
            optionsimage.height -optionsimage.height / 3), optionsimage)) {
            Application.LoadLevel("introscreen");
        }
    }
}
