using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public GameObject prefab;
	public Transform spawnPosition;
	public AudioClip sound;
	public float speed = 12f;
	public float cooldown = 0.5f;
	public string buttonToPress = "Fire1";

	[HideInInspector] public bool cameraShake;
	
	private Animator anim;
	private AudioSource sfx;
	private Rigidbody2D rb;
	private float timeStamp;
	private GameObject bullet;

	void Start () {
		anim = GetComponent<Animator> ();
		sfx = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (Input.GetButtonDown (buttonToPress)) {
			if (Time.time >= timeStamp) {
				ShootBullet ();
				timeStamp = Time.time + cooldown;
			}
		}
	}

	void ShootBullet () {
		anim.SetTrigger ("Shoot");
		sfx.PlayOneShot (sound);
		bullet = Instantiate (prefab, spawnPosition.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (transform.localScale.x) * speed, 0);
		if (rb.velocity.y == 0) {
			cameraShake = true;
		}
	}
}
