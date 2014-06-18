using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour {

	float hSliderValue = .75f;
    public GUISkin GUISkin = null;
    public Texture2D background = null;
    public Texture2D button = null;
    private GUIStyle slider;
    private GUIStyle thumbnail;

    void Start() {
        slider = new GUIStyle(GUISkin.horizontalSlider)
            {
                fixedHeight = background.height,
                fixedWidth  = background.width / 2,

            };
        thumbnail = new GUIStyle(GUISkin.horizontalSliderThumb)
            {
                fixedHeight = button.height,
                fixedWidth = button.width,
            };
    }

    void OnGUI() {
        GUI.skin = GUISkin;

        GUI.skin.horizontalScrollbar.fixedWidth = 200;
        hSliderValue = GUI.HorizontalSlider (new Rect (Screen.width/2 - background.width/4, Screen.height/4, background.width/2, background.height),hSliderValue, 0, 1.0f, slider, thumbnail);
        if (GameObject.Find("Sounds") != null) {
            GameObject aud = GameObject.Find("Background Music");
            aud.GetComponent<AudioSource>().volume = hSliderValue;
        }
    }﻿
}
