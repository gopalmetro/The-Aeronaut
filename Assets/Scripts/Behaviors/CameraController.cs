using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CameraController : MonoBehaviour {

	private GameObject Player;
	private GameObject Cam;

	private readonly float startingCameraYPosition = 0f;

	void Start () {
		Cam = GameObject.Find ("Main Camera");
		Player = GameObject.Find ("player");
	}
	
	void Update () {
		float playerHeight = Player.GetComponent<Renderer> ().bounds.size.y;
		float cameraYPosition;
		if (Player.transform.position.y > startingCameraYPosition) {
			cameraYPosition =  Player.transform.position.y ;
		} else {
			cameraYPosition = startingCameraYPosition;
		}
		Cam.transform.position = new Vector3 (Cam.transform.position.x, cameraYPosition, Cam.transform.position.z);
	}
}
