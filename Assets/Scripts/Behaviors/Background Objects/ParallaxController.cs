using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ParallaxController : MonoBehaviour {

    public GameObject[] clouds;
    public GameObject[] islands;
    public float islandSpeedModifier;
    public float cloudLayerSpeedModifier;
    private Vector3 lastCamPos;

	void Start() {
        lastCamPos = Camera.main.transform.position;
	}
	
	void Update () {
        Vector3 curCamPos = Camera.main.transform.position;
        float yPosDiff = lastCamPos.y - curCamPos.y;
        adjustParallaxPositionsForArray(islands, islandSpeedModifier, yPosDiff);
        adjustParallaxPositionsForArray(clouds,
          cloudLayerSpeedModifier, yPosDiff);
    }

    void adjustParallaxPositionsForArray(GameObject[]
      layerArray, float layerSpeedModifier, float yPosDiff)
    {
        for (int i = 0; i < layerArray.Length; i++)
        {
            Vector3 objPos =
              layerArray[i].transform.position;
            objPos.y += yPosDiff * layerSpeedModifier;
            layerArray[i].transform.position = objPos;
        }
    }
}

/*Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * -direction.y, 0);
 * Vector3 v3Pos = new Vector3(.5f, .5f, 10f);
Vector3 curPos = Camera.main.ViewportToWorldPoint(v3Pos);
Vector3 newPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0f);
//transform.position = Vector3.Lerp(curPos, newPos, 1);

float dampTime = 0.15f;
Vector3 velocity = Vector3.zero;
Vector3 delta = newPos - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)); //(new Vector3(0.5, 0.5, point.z));
Vector3 destination = curPos + delta;
transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
 */