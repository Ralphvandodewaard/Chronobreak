using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrigger : MonoBehaviour {

	public ParticleSystem dust;
	public float yOffset;
	
	private PlayerController playerController;
	private ParticleSystem particle;

	void Start () {
		playerController = GetComponent<PlayerController> ();
	}
	
	void FixedUpdate () {
		if (playerController.spawnDust) {
			particle = Instantiate (dust, new Vector3 (transform.position.x, transform.position.y + yOffset, dust.transform.position.z), Quaternion.identity);
			Destroy (particle.gameObject, 1f);
			playerController.spawnDust = false;
		}
	}
}
