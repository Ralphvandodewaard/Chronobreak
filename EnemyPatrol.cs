using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public float speed = 8f;
	
	private float speedCurrent;
	private Vector3 pathStart;
	private Vector3 pathEnd;
	private Vector3 target;
	
	private Animator anim;
	private SpriteRenderer sr;

	void Start () {
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		
		speedCurrent = speed;
		pathStart = transform.position;
		pathEnd = transform.GetChild (0).position;
		anim.SetFloat ("Speed", 1f);
	}

	void FixedUpdate () {
		if (SlowTime.slowTimeActive) {
			speedCurrent = speed / 4;
		} else if (RewindTime.rewindActive) {
			speedCurrent = -speed;
		} else {
			speedCurrent = speed;
		}

		if (transform.position.x == pathStart.x) {
			target = pathEnd;
			if (sr.flipX) {
				sr.flipX = !sr.flipX;
			}
		} else if (transform.position.x == pathEnd.x) {
			target = pathStart;
			sr.flipX = !sr.flipX;
		}

		transform.position = Vector3.MoveTowards (transform.position, target, speedCurrent * Time.deltaTime);
	}
}
