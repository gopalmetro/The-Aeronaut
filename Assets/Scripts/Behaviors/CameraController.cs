using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//This class handles parallax
public class CameraController : MonoBehaviour {


    public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(0, -1);
	public bool isLinkedToCamera = false;
	public bool isLooping = false;
    public bool isParallaxing = false;
	private GameObject Cam;
	private GameObject Player;
    private Vector3 lastCameraPos;

	private int loopCount;


	void Start() {

        Cam = GameObject.Find("Main Camera");
        Player = GameObject.Find("player");

        if (isLooping) {
			this.loopCount = 0;
        }
	}

	void Update () {
        Parallax();
        looping();
	}

    void looping() {
        if (isLooping) {
            if (this.loopCount >= -1) {
                Cam.transform.position = new Vector3(Cam.transform.position.x, Player.transform.position.y, Cam.transform.position.z);
            }

            //needs work -- cleaner code
        }

        lastCameraPos = Cam.transform.position;
    }

    void Parallax() {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * -direction.y, 0);
        if (Player.rigidbody2D.velocity.y < 0) {
            movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        }
        if (Player.rigidbody2D.velocity.y >= 0) {
            //direction.y = -direction.y;
        }

        if (isParallaxing)
        {
            movement += new Vector3(movement.x, Player.rigidbody2D.velocity.y, 0);
        }
        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera) {
            Camera.main.transform.Translate(movement);
        }
    }
}

/*
void checkIfFirstSceneIsOOB(Transform firstChild, Vector3 lastPosition, Vector3 lastSize) {

        if (!firstChild.renderer.IsVisibleFrom(Camera.main) && isCameraRising())
        {
            GameObject backgroundscene = new GameObject("background" + loopCount);
            backgroundscene.transform.position = new Vector3(firstChild.position.x + 25, lastPosition.y + lastSize.y, firstChild.position.z);
            backgroundscene.transform.localScale = firstChild.transform.localScale;
            backgroundscene.AddComponent<SpriteRenderer>();
            backgroundscene.AddComponent<BoxCollider2D>().isTrigger = true;
            backgroundscene.transform.parent = this.transform.parent;
            this.loopCount++;
            this.expectedFrame++;
            if (expectedFrame == currentFrame)
            {
                expectedFrame++;
            }

            currentFrame = expectedFrame - 1;
            backgroundCheck();
            backgroundscene.GetComponent<SpriteRenderer>().sprite = backgrounds[expectedFrame];
        }
    }

    void checkIfSecondSceneIsOOB(Transform secondChild, Transform firstChild, Vector3 lastPosition, Vector3 lastSize)
    {
        if (!secondChild.renderer.IsVisibleFrom(Camera.main) && !isCameraRising())
        {
            GameObject backgroundscene = new GameObject("background" + loopCount);
            backgroundscene.transform.localScale = firstChild.transform.localScale;
            backgroundscene.AddComponent<SpriteRenderer>();
            backgroundscene.AddComponent<BoxCollider2D>().isTrigger = true;
            backgroundscene.transform.parent = this.transform.parent;
            this.loopCount--;
            this.expectedFrame--;
            if (expectedFrame == currentFrame)
            {
                expectedFrame--;
            }
            currentFrame = expectedFrame + 1;
            backgroundCheck();
            secondChild.GetComponent<SpriteRenderer>().sprite = backgrounds[expectedFrame];
            if (this.loopCount >= -1)
            {
                backgroundscene.transform.position = new Vector3(secondChild.position.x + 25, firstChild.position.y - lastSize.y, firstChild.position.z);
            }
        }
    }
*/