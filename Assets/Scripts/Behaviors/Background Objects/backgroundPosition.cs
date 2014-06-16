using UnityEngine;
using System.Collections;

public class backgroundPosition : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        this.transform.position = new Vector2(Screen.width, Screen.height);
	}
}
