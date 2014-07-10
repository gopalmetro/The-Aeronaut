using UnityEngine;
using System.Collections;

public class scoretext : MonoBehaviour {

    private AchievementController scorer;
    public static int score;
    private int curHighScore = 0;

	// Use this for initialization
	void Start () {
        scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();

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
