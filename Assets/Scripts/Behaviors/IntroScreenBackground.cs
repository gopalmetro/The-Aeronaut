using UnityEngine;
using System.Collections;

public class IntroScreenBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3 (Screen.width, Screen.height, this.transform.localScale.z);
	}
}
