using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour {

    public GameObject[] atmosphericBackgroundObjects;
    public GameObject[] atmosphericForegroundObjects;
    public GameObject[] spaceBackgroundObjects;
    public GameObject[] spaceForegroundObjects;
    private altimeter altimeter;
    
	// Use this for initialization
	void Start () {
        altimeter = GameObject.Find("Floor").GetComponent<altimeter>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
