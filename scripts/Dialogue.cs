using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour {

	public GameObject background;
	public TextMeshProUGUI text;
	public string button = "";
	[TextArea] public string[] dialogue;
	//public Object sceneToLoad;

	private bool startDialogue;
	private int counter;
	
	void Update () {
		if (text.gameObject.activeSelf) {
			if (Input.GetButtonDown(button)) {
				if (counter < dialogue.Length - 1) {
					counter = counter + 1;
					text.text = dialogue[counter];
				} else {
					Time.timeScale = 1f;
					background.SetActive (false);
					text.gameObject.SetActive (false);
					SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
					//SceneManager.LoadScene (sceneToLoad.name);
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player") && !startDialogue) {
			startDialogue = true;
			Time.timeScale = 0;
			background.SetActive (true);
			text.gameObject.SetActive (true);
			text.text = dialogue[0];
		}
	}
}
