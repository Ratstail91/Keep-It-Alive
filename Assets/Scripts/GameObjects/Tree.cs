using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
	static LevelController levelController;
	static GameObject character;

	SpriteRenderer spriteRenderer;

	int life = 3;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		spriteRenderer.sortingOrder = -(int)Mathf.Floor(transform.localPosition.y * 100);

		if (!levelController) {
			levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
		}

		if (!character) {
			character = GameObject.Find("Character");
		}
	}

	void OnTriggerStay2D() {
		if (GamePad.GetState().Pressed(CButton.Y)) {
			life -= 1;

			//wiggle
			StartCoroutine(Wiggle());

			if (life <= 0) {
				Destroy(gameObject);
				levelController.globalWood++;
			}
		}
	}

	IEnumerator Wiggle() {
		float time = 0.5f;

		while (time > 0f) {
			float sign = Mathf.Sign(character.transform.localPosition.x - transform.localPosition.x);
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, sign * 10), time);
			time -= Time.deltaTime;

			yield return null;
		}
	}
}