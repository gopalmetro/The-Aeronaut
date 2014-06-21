using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ParallaxController : MonoBehaviour {

	public bool isParallaxing = false;
	public bool isLinkedToCamera = false;
	public Vector2 speed = new Vector2(2,2);
	public Vector2 direction = new Vector2(0, -1);
	private GameObject Player;
	private GameObject Cam;

	void Start() {
		Cam = GameObject.Find("Main Camera");
		Player = GameObject.Find("player");
	}
	
	void Update () {

		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * -direction.y, 0);

		if (Player.rigidbody2D.velocity.y < 0) {
			movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		}

		if (isParallaxing) {
			movement += new Vector3 (movement.x, Player.rigidbody2D.velocity.y, 0);
		}
			
		movement *= Time.deltaTime;
		transform.Translate (movement);
		
	}
}
