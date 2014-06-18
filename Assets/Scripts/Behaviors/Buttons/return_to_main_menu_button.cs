using UnityEngine;
using System.Collections;

public class return_to_main_menu_button : MonoBehaviour {

	public Texture2D optionsimage;
    public GUISkin GUIskin = null;

    void OnGUI() {
        GUI.skin = GUIskin;
        if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 100, optionsimage.width - optionsimage.width/4, optionsimage.height -optionsimage.height / 4), optionsimage))
        {
            Application.LoadLevel("introscreen");
        }
    }
}
