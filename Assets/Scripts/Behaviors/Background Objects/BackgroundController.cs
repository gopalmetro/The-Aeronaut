using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour {

    public GameObject backgroundPrefab;
    private List<Sprite> backgrounds;
    private List<GameObject> backgroundParts;

	// Use this for initialization
	void Start () {
        backgrounds = new List<Sprite>();
        backgroundParts = new List<GameObject>();
        LoadImages(backgrounds);
        for (int i = 0; i < 3; i++) {
            GameObject newBackground = Instantiate(backgroundPrefab) as GameObject;
            newBackground.GetComponent<Background>().setSprite(backgrounds[i]);
            newBackground.transform.parent = this.transform;
            newBackground.GetComponent<Background>().setIndex(i);
            newBackground.GetComponent<Background>().setColliderBounds();
            backgroundParts.Add(newBackground);
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
