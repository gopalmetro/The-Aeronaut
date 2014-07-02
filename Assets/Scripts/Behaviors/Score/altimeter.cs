using UnityEngine;
using System.Collections;

//gets height of player
public class altimeter : MonoBehaviour {
    
    private GameObject Player;
    AchievementController scorer;
    public int height;

	// Update is called once per frame
	void FixedUpdate () {
		Player = GameObject.Find("player");
		scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();
		if (Player) {
			height = (int)(Player.transform.position.y - this.transform.position.y);
			scorer.setScore (height + 1);
		}
	}

    public int getHeight() {
        return height;
    }
}
