using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour {

	public float hSliderValue = .75f;
    public GUISkin GUISkin = null;
    public Texture2D background = null;
    public Texture2D button = null;
    public string controller = null;
	public int negOrPos = 0;
    private float offset = Screen.width/8;
    private GUIStyle slider;
    private GUIStyle thumbnail;

    void Start() {
		offset = negOrPos * offset;
        slider = new GUIStyle(GUISkin.horizontalSlider) {
                fixedHeight = Screen.width/16,
                fixedWidth  = Screen.width / 2,

            };
        thumbnail = new GUIStyle(GUISkin.horizontalSliderThumb) {
                fixedHeight = Screen.width/8,
                fixedWidth = Screen.width/8 ,
                
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
        hSliderValue = GUI.HorizontalSlider (new Rect (Screen.width / 2 - slider.fixedWidth/2, Screen.height / 4 - offset, 
            Screen.width / 2 , background.height), hSliderValue, 0, 1.0f, slider, thumbnail);
        if (GameObject.Find("Sounds") != null) {
            GameObject aud = GameObject.Find(controller);
            aud.GetComponent<AudioSource>().volume = hSliderValue;
        }
    }﻿
}
