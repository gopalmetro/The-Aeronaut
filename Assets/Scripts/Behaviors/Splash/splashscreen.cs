using UnityEngine;
using System.Collections;

public class splashscreen : MonoBehaviour {

    float timer = 5;

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Application.LoadLevel("introscreen");
        }
	}
}
