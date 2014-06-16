using UnityEngine;
using System.Collections;

public class SafetyButton : MonoBehaviour {

    //purple balloon
    public Transform purpleballoon;
    public int purpcount = 1;

    private GameObject Player;
    private AchievementController scorer;

    void Start() {
        Player = GameObject.Find("player");
        scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();
    }
    //GUI specific actions
    void OnGUI() {

        if (GUI.Button(new Rect(0, 0, 100, 50), "Safety Balloon Count: " + purpcount)) {
            spawnPurpleBalloon();
        }
    }

    public void setPurpcount(int count) {
        purpcount = count;
    }

    void spawnPurpleBalloon() {
        if (purpcount > 0) {
            Transform balloon;
            balloon = Instantiate(purpleballoon) as Transform;
            Vector3 pos = Player.transform.position;
            pos.y = Player.transform.position.y - 10;
            balloon.position = pos;
            balloon.transform.parent = transform.parent;
            purpcount--;
        }
    }

    void controlPurpCount() {
        if (scorer.getScore() % 500 == 0) {
            purpcount++;
        }
    }
}
