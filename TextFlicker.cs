using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFlicker : MonoBehaviour {

	public float speed = 1f;
	public GameObject text;

	private float time;
	
	void Start () {
		time = 1 / speed;
		InvokeRepeating ("Flicker", time, time);
	}
	
	void Flicker () {
		if (text.activeSelf) {
			text.SetActive (false);
		} else {
			text.SetActive (true);
		}
	}
}
