using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour {

    public GameObject backgroundPrefab;
    private List<Sprite> backgrounds;
    private List<GameObject> backgroundParts;

	// Use this for initialization
	void Start () {
        NotificationCenter.defaultCenter.addListener(onNotification, NotificationType.BackgroundObjectNotification);
        backgrounds = new List<Sprite>();
        backgroundParts = new List<GameObject>();
        LoadImages(backgrounds);
        for (int i = 0; i < 3; i++) {
            GameObject newBackground = Instantiate(backgroundPrefab) as GameObject;
            newBackground.GetComponent<Background>().setSprite(backgrounds[i]);
            newBackground.transform.parent = this.transform;
            newBackground.GetComponent<Background>().setIndex(i);
            newBackground.GetComponent<Background>().setID((char)(i + 70));
            newBackground.GetComponent<Background>().setColliderBounds();
            backgroundParts.Add(newBackground);
        }
	}

    private void onNotification(Notification note) {
        BackgroundNotification current = (BackgroundNotification)note;
        Background currentBackground = current.gameObj.GetComponent<Background>();
        List<GameObject> tempBackgroundParts = new List<GameObject>();
        int currentIndex = currentBackground.getIndex();

        foreach (GameObject a in backgroundParts) {
            if (a.GetComponent<Background>().id != currentBackground.id){
                a.GetComponent<Background>().isCenter = false;
                tempBackgroundParts.Add(a);
            }
        }
        tempBackgroundParts[0].GetComponent<Background>().setIndex(currentIndex - 1);
        tempBackgroundParts[1].GetComponent<Background>().setIndex(currentIndex + 1); 
        tempBackgroundParts[0].GetComponent<Background>().setSprite(backgrounds[currentIndex - 1]);
        tempBackgroundParts[1].GetComponent<Background>().setSprite(backgrounds[currentIndex + 1]);
        
    }

    private void BubbleSort()
    {
        int length = backgroundParts.Count;

        GameObject temp = backgroundParts[0];

        for (int i = 0; i < length; i++) {
            for (int j = i + 1; j < length; j++) {
                if (backgroundParts[i].transform.position.y > backgroundParts[j].transform.position.y) {
                    temp = backgroundParts[i];

                    backgroundParts[i] = backgroundParts[j];

                    backgroundParts[j] = temp;
                }
            }
        }
    }

    private void LoadImages(List<Sprite> backgrounds)
    {
        for (int i = 1; i < 09; i++) {
            string texture = "Textures/backgrounds/0" + i;
            Sprite texTmp = (Sprite)Resources.Load(texture, typeof(Sprite));
            backgrounds.Add(texTmp);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
