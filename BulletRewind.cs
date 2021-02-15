using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRewind : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 speedOriginal;
	private Vector2 speed;
	private Vector3 bulletSpawnPosition;
	
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speedOriginal = rb2d.velocity;
		bulletSpawnPosition = transform.position;
	}
	
	void Update () {
		if (speedOriginal.x < 0 && rb2d.velocity.x > 1) {
			if (bulletSpawnPosition.x - transform.position.x < 1) {
				Destroy (gameObject);
			}
		}
		if (speedOriginal.x > 0 && rb2d.velocity.x < 1) {
			if (transform.position.x - bulletSpawnPosition.x < 1) {
				Destroy (gameObject);
			}
		}
	}
	
	void FixedUpdate () {
		if (RewindTime.rewindActive) {
			speed.x = -speedOriginal.x;
			rb2d.velocity = speed;
		} else if (!SlowTime.slowTimeActive) {
			rb2d.velocity = speedOriginal;
		}
	}
}
