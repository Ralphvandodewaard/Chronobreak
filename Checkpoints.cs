using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

	public Material inactive;
	public Material active;
	
	[HideInInspector] public Vector2 checkpoint;
	private MeshRenderer mr;

	void Start () {
		checkpoint = transform.position;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Checkpoint")) {
			checkpoint = transform.position;
			if (mr) {
				mr.material = inactive;
			}
			mr = other.GetComponent<MeshRenderer> ();
			if (mr.material = inactive) {
				mr.material = active;
			}
		}
	}
}
