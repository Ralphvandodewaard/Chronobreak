using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public ParticleSystem blood;
	public AudioClip death;

	private AudioSource sfx;
	private ParticleSystem particle;
	
	void Start () {
		sfx = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("PlayerBullet")) {
			sfx.PlayOneShot (death);
			particle = Instantiate (blood, new Vector3 (transform.position.x, transform.position.y, blood.transform.position.z), Quaternion.identity);
			Destroy (particle.gameObject, 1f);
			gameObject.SetActive (false);
		}
	}
}
