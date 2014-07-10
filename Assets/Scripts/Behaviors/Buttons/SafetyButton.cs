using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SafetyButton : MonoBehaviour {

    //purple balloon
    public Transform purpleballoon;
    public int purpcount = 3;

    private List<Texture2D> lifeContainer;
    private GameObject Player;
    private AchievementController scorer;


    void Start() {
        lifeContainer = new List<Texture2D>();
        LoadImages(lifeContainer);
        Player = GameObject.Find("player");
        scorer = GameObject.Find("Scorer").GetComponent<AchievementController>();
    }

    private void LoadImages (List<Texture2D> lifeContainers) {
		for (int i = 0; i < 04; i++) {
			string texture = "Textures/GUI_Elements/life_container_" + i;
			Texture2D texTmp = (Texture2D)Resources.Load (texture, typeof(Texture2D));
			lifeContainers.Add (texTmp);
		}
	}

    //GUI specific actions
    void OnGUI() {
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        if (GUI.Button(new Rect(Screen.width - 105, Screen.height * .03f, 100, 50), lifeContainer[purpcount])) {
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
