using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MockFire : MonoBehaviour {
	LevelController levelController;
	Animator animator;

	void Awake() {
		levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
		animator = GetComponent<Animator>();
	}

	void Start() {
		animator.speed = 1f / 10f;
		animator.SetInteger("size", 2);
	}

	void Update() {
		if (GamePad.GetState().Pressed(CButton.Y)) {
			SceneManager.LoadScene("Gameplay");
		}

		if (levelController.globalLightLevel < 0.4f) {
			levelController.increment = 0.002f;
		}

		if (levelController.globalLightLevel > 0.6f) {
			levelController.increment = -0.002f;
		}
	}
}