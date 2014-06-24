using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//This class handles parallax
public class CameraController : MonoBehaviour {

	private GameObject Player;
    private GameObject Cam;
    private bool loss = false;

	void Start() {
		Cam = GameObject.Find("Main Camera");
		Player = GameObject.Find("player");
	}

	void Update () {
        if (!loss) {
            Cam.transform.position = new Vector3(Cam.transform.position.x, Player.transform.position.y, Cam.transform.position.z);
        }
    }
}
