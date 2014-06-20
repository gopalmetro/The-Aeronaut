using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public Vector2 startPos = new Vector2(0.028801f, 0);
    public bool isCenter = false;
    private int index = 0;
    private Sprite curSprite;


    public void Awake() {
        this.GetComponent<SpriteRenderer>().sprite = curSprite;
        this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y * 1.5f, this.transform.localScale.z);
    }

    public void setIndex(int ind) {
        this.index = ind;
        this.transform.position = new Vector3(this.transform.position.x, ind * getHeight() + getHeight() / 2, 10);//anchor at 0.5
    }

    public int getIndex() {
        return this.index;
    }

    public void setSprite(Sprite newSprite) {
        this.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public float getHeight() {
        return this.renderer.bounds.size.y;
    }

    public void setColliderBounds() {
        this.GetComponent<BoxCollider2D>().size = new Vector2(this.GetComponent<SpriteRenderer>().sprite.bounds.size.x,
            this.GetComponent<SpriteRenderer>().sprite.bounds.size.y);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Welcome");
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Goodbye");
    }
}
