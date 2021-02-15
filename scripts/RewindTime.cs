using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour {

	public float secondsToRewind = 3f;
	public AudioClip sound;

	List<PositionRecording> positions;

	public static bool rewindActive = false;

	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource sfx;
	private PlayerAbilities playerAbilities;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sfx = GetComponent<AudioSource> ();
		positions = new List<PositionRecording>();
		playerAbilities = GetComponent<PlayerAbilities>();
	}
	
	void Update () {
		if (playerAbilities.rewindTime) {
			if (!SlowTime.slowTimeActive) {
				if (Input.GetAxis ("Rewind") != 0) {
						sfx.PlayOneShot (sound);
						rewindActive = true;
						rb2d.isKinematic = true;
				} else {
					rewindActive = false;
					rb2d.isKinematic = false;
				}
			}
		}
	}
	
	void FixedUpdate () {
		if (rewindActive) {
			Rewind ();
			anim.SetTrigger ("Rewind");
		} else {
			Record ();
		}
	}

	void Rewind () {
		if (positions.Count > 0) {
			PositionRecording PointInTime = positions [0];
			transform.position = PointInTime.position;
			positions.RemoveAt (0);
		} else {
			rewindActive = false;
			rb2d.isKinematic = false;
		}
	}

	void Record () {
		if (positions.Count > (secondsToRewind / 0.02)) {
			positions.RemoveAt (positions.Count - 1);
		}
		positions.Insert (0, new PositionRecording (transform.position));
	}
}
