using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAbility : MonoBehaviour {

	public bool doubleJump;
	public bool shooting;
	public bool slowTime;
	public bool rewindTime;

	private PlayerController playerController;
	private PlayerShooting playerShooting;
	private PlayerAbilities playerAbilities;
	
	void Start () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		playerShooting = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerShooting> ();
		playerAbilities = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAbilities> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			if (doubleJump) {
				playerController.doubleJumpEnabled = true;
			}
			if (shooting) {
				playerShooting.enabled = true;
			}
			if (slowTime) {
				playerAbilities.slowTime = true;
			}
			if (rewindTime) {
				playerAbilities.rewindTime = true;
			}
		}
	}
}
