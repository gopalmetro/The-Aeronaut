using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour {

    public GameObject backgroundPrefab;
    private List<Sprite> backgrounds;
    private List<GameObject> backgroundParts;
    private int heightToBeginTransition = 5;

	// Use this for initialization
	void Start () {
        NotificationCenter.defaultCenter.addListener(onNotification, NotificationType.BackgroundObjectNotification);
        backgrounds = new List<Sprite>();
        backgroundParts = new List<GameObject>();
        LoadImages(backgrounds);

        for (int i = 0; i <= 2; i++) {

            GameObject newBackground = Instantiate(backgroundPrefab) as GameObject;
		

			newBackground.GetComponent<Background>().setSprite(backgrounds[0]);
		
            newBackground.transform.parent = this.transform;
            newBackground.GetComponent<Background>().setIndex(0);
            newBackground.GetComponent<Background>().setHeight(i);
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
        int currentHeight = currentBackground.getHeight();
        foreach (GameObject a in backgroundParts) {
            
			if (a.GetComponent<Background>().id != currentBackground.id){
                a.GetComponent<Background>().isCenter = false;
                tempBackgroundParts.Add(a);
            }
        }

        if (currentHeight < heightToBeginTransition) {
            
            tempBackgroundParts[1].GetComponent<Background>().setIndex(0);
            tempBackgroundParts[1].GetComponent<Background>().setSprite(backgrounds[0]);
            tempBackgroundParts[1].GetComponent<Background>().setHeight(currentHeight + 1);
            tempBackgroundParts[0].GetComponent<Background>().setIndex(0);
            tempBackgroundParts[0].GetComponent<Background>().setSprite(backgrounds[0]);
            tempBackgroundParts[0].GetComponent<Background>().setHeight(currentHeight - 1);
            
        }
        else {
            tempBackgroundParts[1].GetComponent<Background>().setIndex(currentIndex + 1);
            tempBackgroundParts[1].GetComponent<Background>().setSprite(backgrounds[currentIndex + 1]);
            tempBackgroundParts[1].GetComponent<Background>().setHeight(currentHeight + 1);

            if (currentIndex - 1 < 0) {
                tempBackgroundParts[0].GetComponent<Background>().setIndex(currentIndex - 1);
                tempBackgroundParts[0].GetComponent<Background>().setSprite(backgrounds[currentIndex]);
                tempBackgroundParts[0].GetComponent<Background>().setHeight(currentHeight - 1);
            }
            else {
                tempBackgroundParts[0].GetComponent<Background>().setIndex(currentIndex - 1);
                tempBackgroundParts[0].GetComponent<Background>().setSprite(backgrounds[currentIndex - 1]);
                tempBackgroundParts[0].GetComponent<Background>().setHeight(currentHeight - 1);
            }

        }
    }


    private void LoadImages(List<Sprite> backgrounds) {
        for (int i = 1; i < 09; i++) {
            string texture = "Textures/backgrounds/0" + i;
            Sprite texTmp = (Sprite)Resources.Load(texture, typeof(Sprite));
            backgrounds.Add(texTmp);
        }
    }
}
