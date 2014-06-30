using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour {

    public GameObject[] atmosphericBackgroundObjects;
    public GameObject[] atmosphericForegroundObjects;
    public GameObject[] spaceBackgroundObjects;
    public GameObject[] spaceForegroundObjects;
    public Vector2 atmosphericObjectRange;
    public Vector2 spaceObjectRange;
    private altimeter altimeter;
    private int foregroundHeightOffset;
    private int backgroundHeightOffset;
    private GameObject Player;
    private float spawnTimer;
    private int spawnCounter;

    
	// Could also be implemented that an array of background objects get set at random heights when game initializes. Height dependent on where you want the objects 
	void Start () {
        backgroundHeightOffset = 100;
        foregroundHeightOffset = 15;
        altimeter = GameObject.Find("Floor").GetComponent<altimeter>();
        Player = GameObject.Find("player");
        spawnCounter = 1;
        if (spaceObjectRange.y == 0 || atmosphericObjectRange.y == 0) {
            Debug.Log("No heights have been set in Parallax Controller, setting to default");
            atmosphericObjectRange = new Vector2(100, 1000);
            spaceObjectRange = new Vector2(1001, 2000);
        }
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (altimeter.getHeight() > atmosphericObjectRange.x && altimeter.getHeight() < atmosphericObjectRange.y) {
            if (spawnTimer > 10 && spawnCounter == 1){
                GameObject ForeObject;
                int index = Random.Range(0, atmosphericForegroundObjects.Length);
                spawnCounter++;
                ForeObject = (GameObject)Instantiate(atmosphericForegroundObjects[index] as GameObject);
                ForeObject.transform.position = new Vector3(Random.Range(-10, 10),
                    Player.transform.position.y + foregroundHeightOffset, ForeObject.transform.position.z);
            }
            if (spawnTimer > 20 && spawnCounter == 2){
                GameObject BackObject;
                int index = Random.Range(0, atmosphericBackgroundObjects.Length);
                spawnCounter++;
                BackObject = (GameObject)Instantiate(atmosphericBackgroundObjects[index] as GameObject);
                BackObject.transform.position = new Vector3(Random.Range(-10, 10),
                    Player.transform.position.y + backgroundHeightOffset, BackObject.transform.position.z);
            }
        }
        if (altimeter.getHeight() > spaceObjectRange.x && altimeter.getHeight() < spaceObjectRange.y) {
            if (spawnTimer > 10 && spawnCounter == 1) {
                GameObject ForeObject;
                int firstIndex = Random.Range(0, spaceForegroundObjects.Length);
                ForeObject = (GameObject)Instantiate(spaceForegroundObjects[firstIndex] as GameObject);
                ForeObject.transform.position = new Vector3(Random.Range(-10, 10),
                    Player.transform.position.y + foregroundHeightOffset, ForeObject.transform.position.z);
                spawnCounter++;
            }
            if (spawnTimer > 20 && spawnCounter == 2) {
                GameObject ForeObject;
                int secondIndex = Random.Range(0, spaceBackgroundObjects.Length);
                spawnCounter++;
                ForeObject = (GameObject)Instantiate(spaceBackgroundObjects[secondIndex] as GameObject);
                ForeObject.transform.position = new Vector3(Random.Range(-10, 10),
                    Player.transform.position.y + backgroundHeightOffset, ForeObject.transform.position.z);
            }
        }
        if (spawnTimer > 30) {
            spawnTimer = 0;
            spawnCounter = 1;
        }
	}
}
