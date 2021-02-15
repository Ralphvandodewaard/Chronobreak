using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreWallCollision : MonoBehaviour {

	private BoxCollider2D myCollider;
	private GameObject[] walls;
	
	void Start () {
		walls = GameObject.FindGameObjectsWithTag ("Ground");
		myCollider = GetComponent<BoxCollider2D> ();

		foreach (GameObject wall in walls) {
			Physics2D.IgnoreCollision (myCollider, wall.GetComponent<Collider2D>());
		}
	}
}
