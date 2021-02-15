using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public Sprite idle, active;
	public GameObject door;
	public float cooldown = 2f;

	private SpriteRenderer sr;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate () {
		if (sr.sprite == active) {
			door.SetActive (false);
		} else {
			door.SetActive (true);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("PlayerBullet")) {
			Destroy (other.gameObject);
			if (sr.sprite == idle) {
				sr.sprite = active;
				Invoke ("Reset", cooldown);
			}
		}
	}

	void Reset () {
		if (sr.sprite == active) {
			sr.sprite = idle;
		}
	}
}
