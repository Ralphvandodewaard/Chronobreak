using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlowTime : MonoBehaviour {

	public float duration = 3f;
	public float cooldown = 5f;
	public GameObject background;
	public TextMeshProUGUI text;
	public GameObject overlay;
	public AudioClip sound;

	public static bool slowTimeActive = false;

	private AudioSource sfx;
	private PlayerAbilities playerAbilities;
	private float timer;
	[HideInInspector] public float timeStamp;
	private bool isActive;

	void Start () {
		sfx = GetComponent<AudioSource> ();
		playerAbilities = GetComponent<PlayerAbilities>();
		timeStamp = 0 - duration;
	}
	
	void Update () {
		if (playerAbilities.slowTime && !isActive) {
			isActive = true;
			background.SetActive (true);
			text.gameObject.SetActive (true);
		}
		
		if (timer > 0) {
			timer -= Time.deltaTime;
		} else if (timer < 0) {
			timer = 0;
		}

		if (timer == 0) {
			text.text = "Slow time ready!";
		} else {
			text.text = "Cooldown: " + Mathf.Ceil (timer).ToString ("0");
		}

		if (playerAbilities.slowTime) {
			if (!RewindTime.rewindActive) {
				if (Input.GetAxis ("Slow") != 0) {
					if (timer == 0) {
						sfx.PlayOneShot (sound);
						timer = cooldown;
						timeStamp = Time.time;
					}
				}
			}
		}

		if (Time.time < (timeStamp + duration)) {
			slowTimeActive = true;
			overlay.SetActive (true);
		} else {
			slowTimeActive = false;
			overlay.SetActive (false);
		}
	}
}
