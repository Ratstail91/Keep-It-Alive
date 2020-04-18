using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireGoesOut : MonoBehaviour {
	AudioController audioController;

	void Awake() {
		audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

		StartCoroutine(SwitchScenesAfter("MainMenu", 3f));

		audioController.StopAll();
	}

	IEnumerator SwitchScenesAfter(string sceneName, float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}