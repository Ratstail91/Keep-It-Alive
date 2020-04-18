using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour {
	LevelController levelController;
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
	}

	void FixedUpdate() {
		HandleAnimation();
	}

	void HandleAnimation() {
		//determine the brightness based on distance from the center of the tilemap
		float distance = Vector3.Distance(transform.localPosition, Vector3.zero) / 32f;
		float brightness = 1 - Mathf.Log(distance, 10) + levelController.globalLightLevel - 0.5f;

		Color color = Color.white;
		color.r = brightness;
		color.g = brightness;
		color.b = brightness;

		spriteRenderer.color = color;
	}
}