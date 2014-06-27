using UnityEngine;
using System.Collections;

//arraylist & lists
using System.Collections.Generic;

public class BalloonsController : MonoBehaviour {

	public GameObject sceneBalloonObject;
	public int balloonPool = 50;
	private int lastBalloon = -1;
	private GameObject[] balloons;
	public int updateCounter;
	private int balloonIterator = 0;
	private List<Vector2> balloonPositions;
	private List<GameObject> SpawningBalloons;
	private GameObject Cam;
	private GameObject player;
	private scoretext scorer;
	public int distance = 10;
	private float bottomBorder;
	bool forward = true;
	int greenThreshold = 75;
	
	void Start () {
		Cam = GameObject.Find ("Main Camera");
		player = GameObject.Find ("player");
		scorer = GameObject.Find ("Score").GetComponent<scoretext> ();
		SpawningBalloons = new List<GameObject> ();
		updateCounter = 0;
		balloonPositions = getBalloonPositions();
	}
	
	void Awake () {
		balloons = new GameObject[balloonPool];

		for (int i = 0; i < balloons.Length; i++) {
			balloons [i] = Instantiate(sceneBalloonObject) as GameObject;
			balloons [i].SetActive(false);
			balloons [i].transform.parent = transform.parent;
		}
	}
	
	Vector3 getSpawnPosition() {
		
		int i = 0;
		
		if (forward) { 
			i = balloonIterator;
		}  else {
			i = balloonPositions.Capacity - balloonIterator - 1;
		}
		
		return new Vector3 ( this.transform.position.x + balloonPositions[i].x, this.transform.position.y + balloonPositions[i].y - 5, 0);
		
	}
	
	void Update () {
		
		updateCounter++;
		
		if (updateCounter % 30 == 0) {
			
			if (Random.Range(0, 100) > greenThreshold) {
				spawnGreenBalloon ();
			}  else {
				spawnGreenBalloon ();
			}
			
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
	
	
	public GameObject spawnGreenBalloon () {
		
		lastBalloon++;
		if (lastBalloon > balloonPool - 1) {
			lastBalloon = 0;
		}
		GameObject balloon = balloons[lastBalloon];
		
		BalloonScript BalloonMod = balloon.GetComponent<BalloonScript>();

		BalloonMod.deflateRate = .002f;

		string textureName = "Textures/greenballoon";
		Sprite greenBalloon = (Sprite)Resources.Load(textureName, typeof(Sprite));
		
		BalloonMod.isGreen = true;
		BalloonMod.curSprite = greenBalloon;
		
		BalloonMod.speed = new Vector2(0, 30f);
		BalloonMod.direction = new Vector2(0, 1);
		BalloonMod.accel = 2f;
		
		BalloonMod.isGreen = true;
		balloon.transform.position = getSpawnPosition();
		balloon.transform.parent = this.transform.parent;
		
		SpawningBalloons.Add (balloon);
		balloon.SetActive (true);
		return balloon;
	}
	

	
	public List<Vector2> getBalloonPositions() {
		
		List<Vector2> balloonPositions = new List<Vector2> ();
		
		int Xo = -10;
		int width = 20;
		int spawnheight = 4;
		int numberOfSections = 4;
		
		for (int i = 0; i < numberOfSections; i++) {
			
			float sectionXo = Xo + (i*width/numberOfSections);
			float sectionXf = Xo + ((i+1)*width/numberOfSections);
			
			float X = Random.Range(sectionXo, sectionXf);
			float Y = Random.Range(spawnheight - 4, spawnheight);
			balloonPositions.Add (new Vector2 (X, Y));
		}
		
		return balloonPositions;
	}
	
}




