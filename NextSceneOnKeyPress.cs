using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnKeyPress : MonoBehaviour {

	public string keyToPress = "any";
	//public Object sceneToLoad;
	
	private bool buttonIsAny;
	
	void Start () {
		if (keyToPress == "any") {
			buttonIsAny = true;
		}
	}
	
	void Update () {
		if (buttonIsAny) {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
				//SceneManager.LoadScene (sceneToLoad.name);
			}
		} else {
			if (Input.GetKeyDown (keyToPress)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
				//SceneManager.LoadScene (sceneToLoad.name);
			}
		}
	}
}
