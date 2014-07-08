using UnityEngine;
using System.Collections;

public class return_to_settings : MonoBehaviour {

    public Texture2D optionsimage;
    public GUISkin GUIskin = null;

    void OnGUI()
    {
        GUI.skin = GUIskin;
        if (GUI.Button(new Rect(Screen.width * .8f, Screen.height * .01f, optionsimage.width - optionsimage.width / 4,
            optionsimage.height - optionsimage.height / 4), optionsimage)) {
            Application.LoadLevel("settingsscreen");
        }
    }
}
