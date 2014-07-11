using UnityEngine;
using System.Collections;

public class scoretext : MonoBehaviour {
	
    public static int score;
    private int curHighScore = 0;
	private AchievementController scorer;
	private GameObject lives;

	// Use this for initialization
	void Start () {
        scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();
		lives = GameObject.Find ("Lives");
	}
	
	// Update is called once per frame
	void Update () {
        score = scorer.getScore();
        if (score > curHighScore) {
            curHighScore = score;
        }
		this.guiText.text = curHighScore.ToString();
	}

    public int getScore() {
        return score;
    }
}
