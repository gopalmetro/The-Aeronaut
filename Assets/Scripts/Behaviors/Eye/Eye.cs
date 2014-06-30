using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {

    private Vector3 mousePosition;
    private GameObject eye;
    private float initZ;
	// Use this for initialization
	void Start () {
        eye = GameObject.Find("Eye");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches) {
            mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, initZ);

	    // first, find the distance from the center of the eye to the target
        Vector3 distanceToTarget = mousePosition - eye.transform.position;
 
        // clamp the distance so it never exceeds the size of the eyeball
        distanceToTarget = Vector3.ClampMagnitude( distanceToTarget, eye.GetComponent<CircleCollider2D>().radius - this.GetComponent<CircleCollider2D>().radius);
 
        // place the pupil at the desired position relative to the eyeball
        Vector3 finalPupilPosition  = eye.transform.position + distanceToTarget;
        this.transform.position = finalPupilPosition;
	}
}
