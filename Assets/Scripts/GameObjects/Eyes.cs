using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {
	static LevelController levelController;
	static GameObject characterObject;

	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (!levelController) {
			levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
		}

		if (!characterObject) {
			characterObject = GameObject.Find("Character");
		}
	}

	void FixedUpdate() {
		HandleAnimation();
	}

	void HandleAnimation() {
		//determine the brightness based on distance from the center of the tilemap
		float distance = Vector3.Distance(transform.localPosition, Vector3.zero) / 32f;
		float brightness = Mathf.Log(distance, 10) - levelController.globalLightLevel;
		float spooked = Mathf.Log(Vector3.Distance(transform.localPosition, characterObject.transform.localPosition) / 32, 2) - 0.8f;

		if (spooked < 1f && brightness >= 0f) {
			brightness *= spooked;
		}

		Color color = Color.white;
		color.a = brightness;

		spriteRenderer.color = color;
	}
}
