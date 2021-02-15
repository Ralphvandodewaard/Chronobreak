using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowards : MonoBehaviour {

	public Transform target;
	public float speed = 5f;
	public float triggerDistance = 3f;
	
	private float speedCurrent;
	private bool move;

	private Animator anim;
	private SpriteRenderer sr;

	void Start () {
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();

		speedCurrent = speed;
	}

	void Update() {
		if (move) {
			if (SlowTime.slowTimeActive) {
				speedCurrent = speed / 4;
			} else if (RewindTime.rewindActive) {
				speedCurrent = -speed;
			} else {
				speedCurrent = speed;
			}

			float step = speedCurrent * Time.deltaTime;
			Vector3 actualTarget = new Vector3 (target.position.x, transform.position.y, transform.position.z);
			if (target.position.x - transform.position.x < 0) {
				sr.flipX = true;
			} else {
				sr.flipX = false;
			}
			transform.position = Vector3.MoveTowards (transform.position, actualTarget, step);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			move = true;
			anim.SetFloat ("Speed", 1f);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			move = false;
			anim.SetFloat ("Speed", 0);
		}
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.name == "Wall") {
			move = false;
			anim.SetFloat ("Speed", 0);
		}
	}
}
