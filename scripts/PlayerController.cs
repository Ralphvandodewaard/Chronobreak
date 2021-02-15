using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 4f;
	public float jumpPower = 500f;
	public AudioClip jumpSound;
	public bool doubleJumpEnabled;
	
	[HideInInspector] public bool spawnDust;
	[HideInInspector] public bool cameraShake;
	
	private Rigidbody2D rb;
	private Animator anim;
	private AudioSource sfx;
	
	private float horizontalInput;
	private bool facingRight = true;
	private bool isGrounded;
	private bool doJump;
	private bool canDoubleJump;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sfx = GetComponent<AudioSource> ();
	}

	void Update () {
		horizontalInput = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (horizontalInput));
		
		if (Input.GetButtonDown ("Jump") && !RewindTime.rewindActive) {
			if (isGrounded) {
				doJump = true;
				canDoubleJump = true;
			} else if (doubleJumpEnabled) {
				if (canDoubleJump) {
					doJump = true;
					canDoubleJump = false;
				}
			}
		}
	}

	void FixedUpdate () {
		if (!RewindTime.rewindActive) {
			rb.velocity = new Vector2 (horizontalInput * movementSpeed, rb.velocity.y);
		}
		
		if ((horizontalInput > 0 && !facingRight) ||
			(horizontalInput < 0 && facingRight)) {
			facingRight = !facingRight;
			Vector3 tempScale = transform.localScale;
			tempScale.x *= -1;
			transform.localScale = tempScale;
		}
		
		if (doJump) {
			anim.SetTrigger ("Jump");
			sfx.PlayOneShot (jumpSound);

			rb.velocity = new Vector2 (rb.velocity.x, 0);
			rb.AddForce (new Vector2 (0, jumpPower));
			doJump = false;
			isGrounded = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			isGrounded = true;
			if (rb.velocity.y < 0) {
				spawnDust = true;
				cameraShake = true;
			}
		}
	}
	
}
