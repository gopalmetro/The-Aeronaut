using UnityEngine;
using System.Collections;

public class creditsbutton : MonoBehaviour {


    void OnGUI()  {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 50), "Credits!")) {
            Application.LoadLevel("credits");
        }
    }
}
