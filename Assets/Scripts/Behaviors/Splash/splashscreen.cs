using UnityEngine;
using System.Collections;

public class splashscreen : MonoBehaviour {

    float timer = 5;

	void Start() {
		this.transform.position = new Vector3 (0, 0, this.transform.position.z);
		}

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Application.LoadLevel("introscreen");
        }
	}
}
