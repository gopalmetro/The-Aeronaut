using UnityEngine;
using System.Collections;

public class DynamicFonts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUIText font = this.GetComponent<GUIText> ();
		font.fontSize = (int)(font.fontSize + (Screen.width * .01f));
	}
}
