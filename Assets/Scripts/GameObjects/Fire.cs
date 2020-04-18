using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	Animator animator;
	LevelController levelController;

	[SerializeField]
	int size = 1;

	void Awake() {
		animator = GetComponent<Animator>();
		levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
	}

	void Start() {
		animator.speed = 1f / 10f;
	}

	void Update() {
		//change based on global light level
		if (levelController.globalLightLevel <= 0.3f) {
			size = 1;
		} else if (levelController.globalLightLevel < 0.7f) {
			size = 2;
		} else {
			size = 3;
		}
	}

	void FixedUpdate() {
		HandleAnimation();
	}

	void OnTriggerStay2D() {
		if (GamePad.GetState().Pressed(CButton.Y) && levelController.globalWood > 0) {
			levelController.globalWood -= 1;
			levelController.globalLightLevel += 0.2f;
			levelController.globalLightLevel = Mathf.Clamp(levelController.globalLightLevel, 0f, 1f);
		}
	}

	void HandleAnimation() {
		animator.SetInteger("size", size);
	}
}