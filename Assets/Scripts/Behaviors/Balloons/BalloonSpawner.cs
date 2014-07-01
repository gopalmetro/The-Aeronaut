using UnityEngine;
using System.Collections;

//arraylist & lists
using System.Collections.Generic;

public class BalloonSpawner : MonoBehaviour {

    public GameObject balloon;
	public int balloonPool = 50;
	public int updateCounter;
	public int distance = 10;
	private GameObject Cam;
	private GameObject player;
	private GameObject[] balloons;
	private int lastBalloon = -1;
	private int balloonIterator = 0;
	private List<Vector2> balloonPositions;
	private List<GameObject> spawnedBalloons;
	private float bottomBorder;
	private bool forward = true;
	private int greenThreshold = 75;
    private int yellowThreshold = 95;
	
	void Start () {
		Cam = GameObject.Find ("Main Camera");
		player = GameObject.Find ("player");
		spawnedBalloons = new List<GameObject> ();
		updateCounter = 0;
		balloonPositions = getBalloonPositions ();
	}
	
	void Awake () {
		balloons = new GameObject[balloonPool];
		for (int i = 0; i < balloons.Length; i++) {
			balloons [i] = Instantiate (balloon) as GameObject;
			balloons [i].SetActive (false);
			balloons [i].transform.parent = transform.parent;
		}
	}

	private GameObject getNextBalloon () {
		lastBalloon++;
		if (lastBalloon > balloonPool - 1) {
			lastBalloon = 0;
		}
		return balloons [lastBalloon];
	}

	private Vector3 getSpawnPosition () {
		int i = 0;
		if (forward) { 
			i = balloonIterator;
		} else {
			i = balloonPositions.Capacity - balloonIterator - 1;
		}
		return new Vector3 (this.transform.position.x + balloonPositions [i].x, this.transform.position.y + balloonPositions [i].y - 5, 0);
	}

	private List<Vector2> getBalloonPositions () {
		List<Vector2> balloonPositions = new List<Vector2> ();
		int Xo = -10;
		int width = 20;
		int spawnheight = 4;
		int numberOfSections = 4;
		for (int i = 0; i < numberOfSections; i++) {
			float sectionXo = Xo + (i * width / numberOfSections);
			float sectionXf = Xo + ((i + 1) * width / numberOfSections);
			float X = Random.Range (sectionXo, sectionXf);
			float Y = Random.Range (spawnheight - 4, spawnheight);
			balloonPositions.Add (new Vector2 (X, Y));
		}
		return balloonPositions;
	}

	void Update () {

		updateCounter++;
		
		if (updateCounter % 30 == 0) {
			GameObject balloon = getNextBalloon ();
			balloon.transform.parent = this.transform.parent;
			balloon.transform.position = getSpawnPosition ();

			BalloonAppearance balloonAppearance = balloon.GetComponent<BalloonAppearance> ();
			balloonAppearance.direction = new Vector2 (0, 1);
			balloonAppearance.speed = new Vector2 (0, 6f);
			balloonAppearance.accel = 0.0f;
			balloon.SetActive (true);

            int balloonVariety = Random.Range(0, 100);
			if ( yellowThreshold > balloonVariety && balloonVariety > greenThreshold) {
				balloonAppearance.setSprite((Sprite)Resources.Load ("Textures/greenballoon", typeof(Sprite)));
                balloonAppearance.speed = new Vector2(0, 10f);
				balloonAppearance.deflateRate = .002f;
                balloon.name = "SpeedBalloon";
			} else if(balloonVariety > yellowThreshold) {
                balloonAppearance.setSprite((Sprite)Resources.Load("Textures/yellowballoon", typeof(Sprite)));
                balloonAppearance.speed = new Vector2(0, 8f);
                balloonAppearance.deflateRate = .002f;
                balloon.name = "JumpBalloon";
            } else {
				balloonAppearance.setSprite((Sprite)Resources.Load ("Textures/redballoon", typeof(Sprite)));
				balloonAppearance.deflateRate = .001f;
			}

			spawnedBalloons.Add (balloon);

			balloonIterator++;
			if (balloonIterator >= 4) {
				balloonIterator = 0;
				forward = !forward;
				balloonPositions = getBalloonPositions ();
			}
			updateCounter = 0;
		}
		
		var dist = (player.transform.position - Camera.main.transform.position).z;
		bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		this.transform.position = new Vector3 (Cam.transform.position.x, bottomBorder, dist);
	}


}


