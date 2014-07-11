using UnityEngine;
using System.Collections;

public class scoretracker : MonoBehaviour {

	public GUISkin GUIskin = null;
	private AchievementController scorer;
	private SafetyButton lives;
	private static int score;
	private int curHighScore = 0;
	// Use this for initialization
	void Start () {
		scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();
		lives = GameObject.Find ("Lives").GetComponent<SafetyButton>();
	}

	void Update () {
		score = scorer.getScore();
		if (score > curHighScore) {
			curHighScore = score;
		}
	}
	
	void OnGUI() {
		GUI.skin = GUIskin;
		GUI.skin.font = GUIskin.font; 
		GUI.Label(new Rect (10f, 15f, 125, 60), curHighScore.ToString());
	}
}