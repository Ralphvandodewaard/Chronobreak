using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	public GameObject tutorial;
	public GameObject background;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			background.SetActive (true);
			tutorial.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			background.SetActive (false);
			tutorial.SetActive (false);
		}
	}
}
