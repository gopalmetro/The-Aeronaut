using UnityEngine;
using System.Collections;
//arraylist & lists
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject powerUp;
    public int powerUpPool = 5;
    public int timer;
    public int spawntime = 25;
    private List<Vector2> PowerUpCoord;
    private GameObject camera;
    private GameObject player;
    private int lastPowerUp = -1;
    private GameObject[] powerUps;
    private float topBorder;
    private int curPowerup = 0;
    private float Timer;
    private float timeDelay = 5;

	// Use this for initialization
	void Start () {
        timer = 30;
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
	}

    void Awake() {
        Timer = Time.time + timeDelay;
        powerUps = new GameObject[powerUpPool];
        for (int i = 0; i < powerUps.Length; i++) {
            powerUps[i] = Instantiate(powerUp) as GameObject;
            powerUps[i].SetActive(false);
            powerUps[i].transform.parent = transform.parent;
        }
    }

    public GameObject getNextpowerUp() {
        lastPowerUp++;
        if (lastPowerUp > powerUpPool - 1) {
            lastPowerUp = 0;
        }
        return powerUps[lastPowerUp];
    }
	
	// Update is called once per frame
	void Update () {
        if (Timer < Time.time) {
            //GameObject powerup = Instantiate(powerUp) as GameObject;
            GameObject powerup = getNextpowerUp();
            powerup.SetActive(true);
            powerup.transform.position = new Vector3(Random.Range(-10, 10), this.transform.position.y);
            Timer = Time.time + timeDelay;
        }
        var dist = (player.transform.position - Camera.main.transform.position).z;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        transform.position = new Vector3(camera.transform.position.x, topBorder + 5, dist);
	}
}
