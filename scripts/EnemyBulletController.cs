using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	public float timeUntillDestruction = 10f;
	
	void Start () {
		Invoke ("Destroy", timeUntillDestruction);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
		} else if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
		}
	}

	void Destroy () {
		Destroy (gameObject);
	}
}
