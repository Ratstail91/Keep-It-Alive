using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Claws : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		StartCoroutine(FadeOverTime(2f));
		StartCoroutine(SwitchScenesAfter("MainMenu", 5f));
	}

	IEnumerator FadeOverTime(float delay) {
		while (true) {
			Color color = spriteRenderer.color;
			color.a -= delay / 60f;
			spriteRenderer.color = color;

			yield return new WaitForSeconds(delay / 60f);
		}
	}

	IEnumerator SwitchScenesAfter(string sceneName, float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}