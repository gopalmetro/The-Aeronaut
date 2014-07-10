
using UnityEngine;
using System.Collections;

//arraylist & lists
using System.Collections.Generic ;
using System;

public class BalloonSpawner : MonoBehaviour {
	
	public GameObject balloon;
	public int balloonPoolCount = 100;
	public bool gameOver = false;
	private GameObject Cam;
	private GameObject player;
	private GameObject[] balloons;
	private List<GameObject> spawnedBalloons;
	private float playerYPosition;
	private int balloonPoolIterator = -1;
	private int balloonSectionIterator = 0;
	private scoretext scorer;

	private enum BalloonKind {
		SLOW,
		NORMAL,
		SPEED,
		JUMP,
		ARBITRARY }
	;

	private enum BalloonSpawnThreshold {
		SLOW = 0,
		NORMAL = 30,
		SPEED = 75,
		JUMP = 95 }
	;

	void Start () {
		Cam = GameObject.Find ("Main Camera");
		player = GameObject.Find ("player");
		scorer = GameObject.Find ("Score").GetComponent<scoretext> ();
		spawnedBalloons = new List<GameObject> ();
		playerYPosition = player.transform.position.y;
		float zDistance = (player.transform.position - Camera.main.transform.position).z;
		float bottomOfCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, zDistance)).y;
		this.transform.position = new Vector3 (0, bottomOfCamera, zDistance);

		NotificationCenter.defaultCenter.addListener (onDeath, NotificationType.Death);

	}
	
	void Awake () {
		balloons = new GameObject[balloonPoolCount];
		for (int i = 0; i < balloons.Length; i++) {
			balloons [i] = Instantiate (balloon) as GameObject;
			balloons [i].SetActive (false);
			balloons [i].transform.parent = transform.parent;
		}
	}
	
	void Update () {

		float zDistance = (player.transform.position - Camera.main.transform.position).z;
		float bottomOfCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, zDistance)).y;
		float topOfCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1.5f, zDistance)).y;

		if (isMovingUp ()) {
			if (numberAbove (topOfCamera) < 5) {
				spawnBalloon (topOfCamera, BalloonKind.ARBITRARY);
			}  
			if (numberAbove (topOfCamera, "SlowBalloon") < 1) {
				spawnBalloon (topOfCamera, BalloonKind.SLOW);
			}  
		} 

		if (isMovingDown ()) {
			if (numberBeneath (bottomOfCamera) < 5) {
				spawnBalloon (bottomOfCamera, BalloonKind.ARBITRARY);
			}    
			if (numberBeneath (bottomOfCamera, "NormalBalloon") < 1) {
				spawnBalloon (bottomOfCamera, BalloonKind.NORMAL);
			}   
		}
	}

	private void onDeath (Notification Note) {
		try {
			try {
				this.gameOver = true;
				foreach (GameObject obj in spawnedBalloons) {
					Physics2D.IgnoreCollision (obj.collider2D, GameObject.Find ("player").collider2D);
				}
			} catch (MissingReferenceException e) {//unity
			}
		} catch (System.NullReferenceException) {//ios
		}
	}
	
	private void spawnBalloon (float location, BalloonKind balloonKind) {

		GameObject balloon = getNextBalloon ();
		balloon.transform.parent = this.transform.parent;
		balloon.transform.position = getSpawnPosition (location);

		BalloonAppearance balloonAppearance = balloon.GetComponent<BalloonAppearance> ();
		balloonAppearance.direction = new Vector2 (0, 1);
		balloonAppearance.accel = 0.0f;
		balloon.SetActive (true);

		if (balloonKind == BalloonKind.ARBITRARY) {
			int randomNumber = UnityEngine.Random.Range (0, 100);
			if (randomNumber > (int)BalloonSpawnThreshold.JUMP) {
				balloonKind = BalloonKind.JUMP;
			} else if (randomNumber > (int)BalloonSpawnThreshold.SPEED) {
				balloonKind = BalloonKind.SPEED;
			} else if (randomNumber > (int)BalloonSpawnThreshold.NORMAL) {
				balloonKind = BalloonKind.NORMAL;
			} else {
				balloonKind = BalloonKind.SLOW;
			} 
		}

		switch (balloonKind) {
		case BalloonKind.SLOW:
			balloonAppearance.setSprite ((Sprite)Resources.Load ("Textures/blueballoon", typeof(Sprite)));
			balloonAppearance.speed = new Vector2 (0, 3f);
			balloonAppearance.deflateRate = .0f;
			balloon.name = "SlowBalloon";
			break;
		case BalloonKind.NORMAL:
			balloonAppearance.setSprite ((Sprite)Resources.Load ("Textures/red_sphere", typeof(Sprite)));
			balloonAppearance.speed = new Vector2 (0, 6f);
			balloonAppearance.deflateRate = .0f;
			balloon.name = "NormalBalloon";
			break;		
		case BalloonKind.SPEED:
			balloonAppearance.setSprite ((Sprite)Resources.Load ("Textures/green_sphere", typeof(Sprite)));
			balloonAppearance.speed = new Vector2 (0, 12f);
			balloonAppearance.deflateRate = .0f;
			balloon.name = "SpeedBalloon";
			break;
		case BalloonKind.JUMP:
			balloonAppearance.setSprite ((Sprite)Resources.Load ("Textures/yellow_sphere", typeof(Sprite)));
			balloonAppearance.speed = new Vector2 (0, 8f);
			balloonAppearance.deflateRate = .0f;
			balloon.name = "JumpBalloon";
			break;

		}
		spawnedBalloons.Add (balloon);

		if (gameOver) {
			Physics2D.IgnoreCollision (balloon.collider2D, GameObject.Find ("player").collider2D);
		}
	}
	
	private Vector3 getSpawnPosition (float yLocation) {

		int i = 0;
		int Xo = -10;
		int width = 20;
		int spawnheight = 0;
		int numberOfSections = 2;

		balloonSectionIterator++;
		if (balloonSectionIterator >= 2) {
			balloonSectionIterator = 0;
		}
		float sectionXo = Xo + (balloonSectionIterator * width / numberOfSections);
		float sectionXf = Xo + ((balloonSectionIterator + 1) * width / numberOfSections);
		float X = UnityEngine.Random.Range (sectionXo, sectionXf);
		float Y = UnityEngine.Random.Range (spawnheight - 5, spawnheight);

		return new Vector3 (X, yLocation + Y, 0);
	}
	
	private bool isMovingDown () {
		bool answer = player.transform.position.y >= playerYPosition;
		playerYPosition = player.transform.position.y; 
		return answer;
	}
	
	private bool isMovingUp () {
		bool answer = player.transform.position.y <= playerYPosition;
		playerYPosition = player.transform.position.y; 
		return answer;
	}
	
	private int numberBeneath (float bottomOfCamera, String name = null) { 
		Vector3 position1 = (player.transform.position + (new Vector3 (-10, 0, 0)));
		Vector3 position2 = (new Vector3 (0, bottomOfCamera, 0) + (new Vector3 (10, -20, 0)));
		Collider2D[] hits = Physics2D.OverlapAreaAll (new Vector2 (position1.x, position1.y), new Vector2 (position2.x, position2.y));
		int count = 0;

		foreach (Collider2D hit in hits) {
			if (hit.tag == "platform") {
				if (name == null || hit.name == name)
					count++;
			}
		}
		return (int)System.Math.Ceiling ((double)(count / 2));//two colliders per ball
	}
	
	private int numberAbove (float topOfCamera, String name = null) { 
		Vector3 position1 = (player.transform.position + (new Vector3 (-10, 0, 0)));
		Vector3 position2 = (new Vector3 (0, topOfCamera, 0) + (new Vector3 (10, +10, 0)));
		Collider2D[] hits = Physics2D.OverlapAreaAll (new Vector2 (position1.x, position1.y), new Vector2 (position2.x, position2.y));
		int count = 0;
		foreach (Collider2D hit in hits) {
			if (hit.tag == "platform") {
				if (name == null || hit.name == name)
					count++;
			}
		}
		return (int)System.Math.Ceiling ((double)(count / 2));//two colliders per ball
	}

	private GameObject getNextBalloon () {
		balloonPoolIterator++;
		if (balloonPoolIterator > balloonPoolCount - 1) {
			balloonPoolIterator = 0;
		}
		return balloons [balloonPoolIterator];
	}
}

