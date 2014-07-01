using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {


    float speed = 0.2f;
    bool crawling = true;

	// Use this for initialization
	void Start () {
        GUIText tc = this.GetComponent<GUIText>();
        string creds = "Chielo Zimmerman \n";
        creds += "David Wert \n";
        creds += "Gil Edi \n";
        creds += "Coshx Labs \n";

        tc.text = creds;
	}
	
	// Update is called once per frame
	void Update () {
        if (!crawling)
            return;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (gameObject.transform.position.y > .8) {
            crawling = false;
        }
	}
}
