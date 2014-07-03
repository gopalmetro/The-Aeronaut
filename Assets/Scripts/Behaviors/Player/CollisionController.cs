﻿using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	private float newDeflateRate = .006f;
    private Jump jump;


	void Start () {
		DontDestroyOnLoad (this);
        jump = this.GetComponent<Jump>();
	}
	void FixedUpdate () {
		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds () {
		if (transform.position.x >= 10.01) {
			transform.position = new Vector3 (10.01f, transform.position.y, transform.position.z);
		}
		if (transform.position.x < -10) {
			transform.position = new Vector3 (-10, transform.position.y, transform.position.z);
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
        if (other.gameObject.name == "JumpBalloon") {
            //this.rigidbody2D.velocity += new Vector2(0, 10); this makes the yellow balloon bouncy
            jump.jumpConstant = 2.5f;
        }

        if (other.gameObject.name == "SpeedBalloon") {
            jump.playerSpeed = 10;

            //we can implement these power ups to last through x seconds of time
        }
    }
}
