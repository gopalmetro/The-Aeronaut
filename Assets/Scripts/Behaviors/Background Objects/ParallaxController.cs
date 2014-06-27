using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour {

    public GameObject[] atmosphericBackgroundObjects;
    public GameObject[] atmosphericForegroundObjects;
    public GameObject[] spaceBackgroundObjects;
    public GameObject[] spaceForegroundObjects;
    public int transitionHeight;
    private altimeter altimeter;
    private float spawnTimer;
    private int spawnCounter;

    
	// Use this for initialization
	void Start () {
        altimeter = GameObject.Find("Floor").GetComponent<altimeter>();
        spawnCounter = 1;
        if (transitionHeight == null)
        {
            transitionHeight = 500;
        }
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (altimeter.getHeight() < transitionHeight)
        {
            if (spawnTimer > 100 && spawnCounter == 1)
            {
                int firstIndex = Random.Range(0, atmosphericBackgroundObjects.Length);
                spawnCounter++;
            }
            if (spawnTimer > 200 && spawnCounter == 2)
            {
                int secondIndex = Random.Range(0, atmosphericForegroundObjects.Length);
                spawnCounter++;
            }

        }
        if (altimeter.getHeight() > transitionHeight)
        {
            if (spawnTimer > 100 && spawnCounter == 1)
            {
                int firstIndex = Random.Range(0, spaceBackgroundObjects.Length);
            }
            if (spawnTimer > 200 && spawnCounter == 2)
            {
                int secondIndex = Random.Range(0, spaceForegroundObjects.Length);
            }
        }
        if (spawnTimer > 300)
        {
            spawnTimer = 0;
            spawnCounter = 1;
        }
	}
}
