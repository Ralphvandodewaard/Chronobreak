using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 5f;
	
	private float speedCurrent;
	private Vector3 pathStart;
	private Vector3 pathEnd;
	private Vector3 target;

	void Start () {
		speedCurrent = speed;
		pathStart = transform.position;
		pathEnd = transform.GetChild (0).position;
	}

	void FixedUpdate () {
		if (SlowTime.slowTimeActive) {
			speedCurrent = speed / 4;
		} else if (RewindTime.rewindActive) {
			speedCurrent = -speed;
		} else {
			speedCurrent = speed;
		}

		if (transform.position == pathStart) {
			target = pathEnd;
		} else if (transform.position == pathEnd) {
			target = pathStart;
		}

		transform.position = Vector3.MoveTowards (transform.position, target, speedCurrent * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.transform.parent = transform;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.transform.parent = null;
		}
	}
}
