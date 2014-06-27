using UnityEngine;
using System.Collections;

public class SafetyBalloon : MonoBehaviour {
  
    public int spawnconst = 11;

    //camera
    private GameObject player;

	// Use this for initialization
	void Start () {
        Float BalloonFloat = this.GetComponent<Float>();
        Deflate BalloonDeflate = this.GetComponent<Deflate>();
        BalloonFloat.speed = new Vector2(0, .5f);
        BalloonFloat.direction = new Vector2(0, 1);
        BalloonFloat.accel = 2f;
        BalloonDeflate.deflateRate = .003f;
        player = GameObject.Find("player");
        Vector3 curCamPos = camera.transform.position;
        curCamPos.x = player.transform.position.x;
        curCamPos.y -= spawnconst;
        curCamPos.z = 10;
        this.transform.position = curCamPos;
	}
}
