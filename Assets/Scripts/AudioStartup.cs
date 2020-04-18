using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStartup : MonoBehaviour {
	AudioController controller;
	void Awake() {
		controller = GetComponent<AudioController>();
		controller.Load("fire", "Fire");
		controller.Load("crackle", "Fire Cracks");
		controller.Load("cut", "Tree Cut");
		controller.Load("hunted", "Hunted");
	}
}