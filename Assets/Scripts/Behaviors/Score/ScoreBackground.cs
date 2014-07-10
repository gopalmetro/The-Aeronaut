using UnityEngine;
using System.Collections;

public class ScoreBackground : MonoBehaviour {

	public GameObject Score;
	// Use this for initialization
	void Start () {
		Score = GameObject.Find ("Score");
		this.transform.position = Score.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
