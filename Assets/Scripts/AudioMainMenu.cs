using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMainMenu : MonoBehaviour {
	AudioController controller;

	void Start() {
		controller = GameObject.Find("AudioController").GetComponent<AudioController>();
	}

	void Update() {
		//won't work in start, for some reason
		if (controller.GetPlaying("fire") == false) {
			controller.Play("fire", AudioController.Mode.LOOP);
		}
	}
}