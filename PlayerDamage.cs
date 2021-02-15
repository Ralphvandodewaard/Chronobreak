using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

	public AudioClip damage;

	[HideInInspector] public bool cameraShake;

	private GameObject[] enemies;

	private AudioSource sfx;
	private Checkpoints checkpoints;
	private SlowTime slowTime;
	private TrailRenderer trail;
	
	void Start () {
		sfx = GetComponent<AudioSource> ();
		checkpoints = GetComponent<Checkpoints> ();
		slowTime = GetComponent<SlowTime> ();
		trail = GetComponent<TrailRenderer> ();

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Enemy") ||
			other.gameObject.CompareTag ("Lava")) {
			sfx.PlayOneShot (damage);
			cameraShake = true;
			slowTime.timeStamp = slowTime.timeStamp - 3f;
			transform.position = checkpoints.checkpoint;
			trail.Clear ();

			foreach (GameObject enemy in enemies) {
				enemy.GetComponent<EnemyRespawn> ().Respawn ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyBullet")) {
			sfx.PlayOneShot (damage);
			cameraShake = true;
			slowTime.timeStamp = slowTime.timeStamp - 3f;
			trail.Clear ();
			transform.position = checkpoints.checkpoint;

			foreach (GameObject enemy in enemies) {
				enemy.GetComponent<EnemyRespawn> ().Respawn ();
			}
		}
	}
}
