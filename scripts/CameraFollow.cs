using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public bool onlyFollowX;
	public Vector2 offset;
	public float smoothing = 0.1f;
	
	void FixedUpdate () {
		if (onlyFollowX) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x + offset.x, transform.position.y, transform.position.z), smoothing);
		} else {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x + offset.x, target.position.y + offset.y, transform.position.z), smoothing);
		}
	}
}
