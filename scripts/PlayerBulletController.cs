using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	public float timeUntillDestruction = 10f;
	public AudioClip deflectSound;
	
	private AudioSource sfx;
	
	void Start () {
		sfx = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();
		Invoke ("Destroy", timeUntillDestruction);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Enemy")) {
			Destroy (gameObject);
		} else if (other.gameObject.CompareTag("Ground")) {
			Destroy (gameObject);
		} else if (other.gameObject.CompareTag("Shield")) {
			sfx.PlayOneShot (deflectSound);
			Destroy (gameObject);
		}
	}

	void Destroy () {
		Destroy (gameObject);
	}
}
