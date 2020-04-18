using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {
	//components
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;

	//movement
	float horizontalInput;
	float verticalInput;
	float lastHorizontalInput;
	float lastVerticalInput;
	const float deadZone = 0.15f;
	const float maxSpeed = 60f;
	const float moveForce = 400f;

	//hunting
	FadeToBlack fadeToBlack;
	float huntingTime;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		fadeToBlack = GetComponent<FadeToBlack>();
	}

	void Update() {
		HandleInput();
	}

	void FixedUpdate() {
		HandleMovement();
		HandleAnimation();
		HandleHunted();
	}

	void HandleInput() {
		horizontalInput = GamePad.GetAxis(CAxis.LX);
		verticalInput = -GamePad.GetAxis(CAxis.LY);

		if (Mathf.Abs(horizontalInput) > deadZone || Mathf.Abs(verticalInput) > deadZone) {
			lastHorizontalInput = horizontalInput;
			lastVerticalInput = verticalInput;
		}
	}

	void HandleMovement() {
		//stop the player if input in that direction has been removed
		if (horizontalInput * rb.velocity.x <= 0) {
			rb.velocity = new Vector2(rb.velocity.x * 0.65f, rb.velocity.y);
		}

		if (verticalInput * rb.velocity.y <= 0) {
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.65f);
		}

		//move in the inputted direction, if not at max speed
		if (horizontalInput * rb.velocity.x < maxSpeed) {
			rb.AddForce(Vector2.right * horizontalInput * moveForce);
		}

		if (verticalInput * rb.velocity.y < maxSpeed) {
			rb.AddForce(Vector2.up * verticalInput * moveForce);
		}
	}

	void HandleAnimation() {
		spriteRenderer.sortingOrder = -(int)Mathf.Floor(transform.localPosition.y * 100);
		spriteRenderer.flipX = lastHorizontalInput > 0f;
	}

	void HandleHunted() {
		if (fadeToBlack.brightness < 0f) {
			huntingTime -= Time.deltaTime;
		} else {
			huntingTime = 3f;
		}

		if (huntingTime <= 0f) {
			SceneManager.LoadScene("Claws");
		}
	}
}