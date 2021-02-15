using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 speedOriginal;
	private Vector2 speed;
	
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speedOriginal = rb2d.velocity;
	}

	void FixedUpdate () {
		if (SlowTime.slowTimeActive) {
			speed.x = speedOriginal.x / 4;
			rb2d.velocity = speed;
		} else if (!RewindTime.rewindActive) {
			rb2d.velocity = speedOriginal;
		}
	}
}
