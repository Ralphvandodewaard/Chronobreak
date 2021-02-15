using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject prefab;
	public Transform spawnPosition;
	public float speed = 10f;
	public float cooldown = 3f;

	private float cooldownCurrent;
	private GameObject bullet;

	private Animator anim;

	void OnEnable () {
		cooldownCurrent = cooldown;
		anim = GetComponent<Animator> ();

		StartCoroutine (ShootBullet ());
	}

	void OnDisable () {
		StopCoroutine (ShootBullet ());
	}

	IEnumerator ShootBullet () {
		while (true) {
			Shoot ();
			yield return new WaitForSeconds (cooldownCurrent);
		}
	}

	void Shoot () {
		anim.SetTrigger ("Shoot");
		bullet = Instantiate (prefab, spawnPosition.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (transform.localScale.x) * speed, 0);
	}
}
