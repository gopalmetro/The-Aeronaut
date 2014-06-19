using UnityEngine;
using System.Collections;

public class finalscore : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (PlayerPrefs.GetInt("Score") != null) {
            this.guiText.text = PlayerPrefs.GetInt("Score") + "";
        }
        else {
            this.guiText.text = "0";
        }
	}
}
