using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour {

	public float hSliderValue = .75f;
    public GUISkin GUISkin = null;
    public Texture2D background = null;
    public Texture2D button = null;
    public string controller = null;
    public float posY = 0f;
    private GUIStyle slider;
    private GUIStyle thumbnail;

    void Start() {
        slider = new GUIStyle(GUISkin.horizontalSlider) {
                fixedHeight = background.height,
                fixedWidth  = background.width / 2,

            };
        thumbnail = new GUIStyle(GUISkin.horizontalSliderThumb) {
                fixedHeight = button.height - button.width / 4,
                fixedWidth = button.width - button.width / 4,
                
            };
    }

    void Awake() {
        if (GameObject.Find("Sounds") != null) {
            hSliderValue = GameObject.Find(controller).GetComponent<AudioSource>().volume;
        }
    }

    void OnGUI() {

        GUI.skin = GUISkin;

        GUI.skin.horizontalScrollbar.fixedWidth = 200;
        hSliderValue = GUI.HorizontalSlider (new Rect (Screen.width / 2 - background.width / 4, Screen.height / 4 - posY, 
            background.width / 2 , background.height), hSliderValue, 0, 1.0f, slider, thumbnail);
        if (GameObject.Find("Sounds") != null) {
            GameObject aud = GameObject.Find(controller);
            aud.GetComponent<AudioSource>().volume = hSliderValue;
        }
    }﻿
}
