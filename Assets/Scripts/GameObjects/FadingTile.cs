using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingTile : MonoBehaviour {
	static LevelController levelController;

	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (!levelController) {
			levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
		}
	}

	void FixedUpdate() {
		HandleAnimation();
	}

	void HandleAnimation() {
		//determine the brightness based on distance from the center of the tilemap
		float distance = Vector3.Distance(transform.localPosition, Vector3.zero) / 32f;

		//bugfix for tile under the fire
		if (distance == 0) {
			distance = 0.5f;
		}

		float brightness = 1 - Mathf.Log(distance, 10) + levelController.globalLightLevel - 0.5f;

		Color color = Color.white;
		color.a = brightness;

		spriteRenderer.color = color;
	}
}
