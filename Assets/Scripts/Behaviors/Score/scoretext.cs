using UnityEngine;
using System.Collections;

public class scoretext : MonoBehaviour {

    private AchievementController scorer;
    public static int score;

	// Use this for initialization
	void Start () {
        scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();

	}
	
	// Update is called once per frame
	void Update () {
        score = scorer.getScore();
		this.guiText.text = score.ToString ();;
	}

    public int getScore() {
        return score;
    }
}
