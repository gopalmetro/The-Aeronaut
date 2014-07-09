using UnityEngine;
using System.Collections;

public class return_to_main_menu_button : MonoBehaviour {

	public Texture2D optionsimage;
    public GUISkin GUIskin = null;

    void OnGUI() {
        GUI.skin = GUIskin;
		float constant = optionsimage.height / 3 - Screen.width / 27;
		if (GUI.Button(new Rect(Screen.width*.5f - ((optionsimage.width-constant)/2), Screen.height*.7f, optionsimage.width - constant,
		                        optionsimage.height -constant), optionsimage)) {
            Application.LoadLevel("introscreen");
        }
    }
}
