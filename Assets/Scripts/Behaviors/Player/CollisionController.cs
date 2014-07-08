using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	private float newDeflateRate = .006f;
    private Jump jump;
    private Controls controls;
    private string previousBalloon;
	private float distance;
	private float leftBorder;
	private float rightBorder;
	private Rigidbody2D playerBody;


	void Start () {
		DontDestroyOnLoad (this);
        jump = this.GetComponent<Jump>();
        controls = this.GetComponent<Controls>();
		playerBody = this.gameObject.GetComponent<Rigidbody2D> ();

		distance = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)).x;

	}

	void FixedUpdate () {
		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds () {

		if (transform.position.x + this.renderer.bounds.size.x >= rightBorder) {
						//transform.position = new Vector3 ( rightBorder - 1f, transform.position.y, transform.position.z);
						jump.rightMovementAllowed = false;
		} 
		if (transform.position.x - this.renderer.bounds.size.x <= leftBorder) {
						//transform.position = new Vector3 ( leftBorder + 1f, transform.position.y, transform.position.z);					
			jump.leftMovementAllowed = false;
		} 

		if (rigidbody2D.velocity.y < -3) {
			rigidbody2D.velocity -= new Vector2 (rigidbody2D.velocity.x, .1f);
		}
		if (rigidbody2D.velocity.y < -30) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -30);
		}	
	}

    public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "platform") {
            jump.setGrounded(true);
            jump.jumpConstant = 1f;
            jump.playerSpeed = 5;
            balloonPowerUps(other, jump);
        }
    }

    public void balloonPowerUps(Collision2D other, Jump jump){
        if (controls.gameOver == true) {
            if (other.gameObject.name != "grass") {
                Physics2D.IgnoreCollision(this.gameObject.collider2D, other.gameObject.collider2D);
            }
        }
        else {
            if (other.gameObject.name == "JumpBalloon") {
                //this.rigidbody2D.velocity += new Vector2(0, 10); this makes the yellow balloon bouncy
                jump.jumpConstant = 2.5f;
                previousBalloon = other.gameObject.name;
            }

            if (other.gameObject.name == "SpeedBalloon") {
                jump.playerSpeed = 10;
                previousBalloon = other.gameObject.name;
                //we can implement these power ups to last through x seconds of time
            }
        }
    }
}
