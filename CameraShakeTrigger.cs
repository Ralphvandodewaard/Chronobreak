using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeTrigger : MonoBehaviour {

	public GameObject cameraAnchor;
	
	private CameraShaker cameraShaker;
	private PlayerController playerController;
	private PlayerShooting playerShooting;

	void Start () {
		cameraShaker = cameraAnchor.GetComponent<CameraShaker> ();
		playerController = GetComponent<PlayerController> ();
		playerShooting = GetComponent<PlayerShooting> ();
	}
	
	void Update () {
		if (playerShooting.cameraShake) {
			cameraShaker.DefaultPosInfluence = new Vector3 (2f, 0f, 0f);
			doShake ();
			playerShooting.cameraShake = false;
		}

		if (playerController.cameraShake) {
			cameraShaker.DefaultPosInfluence = new Vector3 (0.3f, 1f, 0f);
			doShake ();
			playerController.cameraShake = false;
		}
	}
	
	void doShake () {
		CameraShaker.Instance.ShakeOnce (1f, 1f, 0, 0.5f);
	}
}
