using UnityEngine;
using System.Collections;

public class BalloonAppearance : MonoBehaviour {

    public bool isVisible = false;
    public bool hasBecomeVisible = false;
    public Sprite curSprite;
    public bool isGreen = false;
	public float deflateRate;
	public bool playerCheck = false;
	public Vector2 speed;
	public Vector2 direction;
	public int floatingConst;
	public float accel;

	protected Vector3 originalScale;
	protected Vector2 movement;
	protected float originalDeflateRate;
	protected float collisionDeflateRate = .006f;

	public Vector2 getSpeed() {return speed;}
	public float getAcceleration() {return accel;}
	public Vector2 getDirection() {return direction;}
	public void setSpeed(Vector2 newSpeed) {this.speed = newSpeed;}
	public void setAcceleration(float accel) {this.accel = accel;}
	public void setDirection(Vector2 newDirection) {this.direction = newDirection;}
	public float getDeflateRate() {return deflateRate;}
	public void setDeflateRate(float newrate) {this.deflateRate = newrate;}
	public void setSprite(Sprite image) { this.GetComponent<SpriteRenderer>().sprite = image;}
	

	void Start () {
		floatingConst = 4;
		originalScale = this.transform.localScale;
		this.GetComponent<SpriteRenderer>().sprite = curSprite;
		originalDeflateRate = this.deflateRate;
	}

	void Update () {
		isVisible = this.renderer.IsVisibleFrom (Camera.main);
		if (this.transform.localScale.x < .2 && !isVisible) {
			Destroy();
		}
		deflate();
		playerCollision();
		handleMovement();
	}

	protected void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
	
	protected void handleMovement() {
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y / floatingConst);
		speed += new Vector2(0, .01f);
		this.transform.Translate(Vector3.up * accel * Time.deltaTime);
		var dist = 0;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		bool check = this.GetComponent<BalloonAppearance>().hasBecomeVisible;
		if (this.transform.position.y > topBorder || (this.transform.position.y < bottomBorder - 50 && !check)) {
			this.GetComponent<BalloonAppearance>().Destroy();
		}
	}

	public void Destroy() {
        Notification balloonPop = new Notification(NotificationType.BalloonPop, "Balloon Popped!");
        NotificationCenter.defaultCenter.postNotification(balloonPop);
        this.transform.localScale = originalScale;
        this.Reset();
        this.gameObject.SetActive(false);
    }

    protected void OnDisable() {
        CancelInvoke();
    }

	public void OnCollisionEnter2D(Collision2D other) {
      
        if (other.gameObject.tag == "floor" && isVisible) {
            Physics2D.IgnoreCollision(this.gameObject.collider2D, other.gameObject.collider2D);
        }
        if (other.gameObject.tag == "platform" && !isVisible) {
            Destroy();
        }
        if (other.gameObject.tag == "Player") {
            this.playerCheck = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "platform" && !isVisible && !isGreen) {
            Invoke("Destroy", 0f);
        }
    }

	void playerCollision() {
		if (playerCheck) {
			this.deflateRate = collisionDeflateRate;

			BalloonAppearance balloonApp = this.gameObject.GetComponent<BalloonAppearance>();
			if (balloonApp.isGreen) {
				this.setSpeed(new Vector2(0, 25f));
			}
			else { 
				this.setSpeed(new Vector2(0, 20f));
			}
		}
	}
	
	public void Reset() {
		this.deflateRate = originalDeflateRate;
		playerCheck = false;
	}
	
	protected void deflate() {
		float xcheck = transform.localScale.x;
		if (xcheck >= 0) {
			Vector3 reduce = new Vector3(deflateRate, deflateRate, 0);
			transform.localScale -= reduce;
		}
		
		if(xcheck <= 0) {
			this.GetComponent<BalloonAppearance>().Destroy();
			this.deflateRate = originalDeflateRate;
		}
	}
}
