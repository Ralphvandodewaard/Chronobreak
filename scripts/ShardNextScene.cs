using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShardNextScene : MonoBehaviour {

	public GameObject text;
	public GameObject background;
	
	void OnTriggerEnter2D (Collider2D other) {
		text.SetActive (true);
		background.SetActive (true);
		gameObject.SetActive (false);
		Invoke ("NextScene", 5);
	}

	void NextScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
