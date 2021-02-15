using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour {

	private Vector3 spawnPosition;
	
	void Start () {
		spawnPosition = transform.position;
	}
	
	public void Respawn () {
		gameObject.SetActive (true);
		transform.position = spawnPosition;
	}
}
