using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireGoesOut : MonoBehaviour {
	void Awake() {
		//TODO: play extinguished sound
		StartCoroutine(SwitchScenesAfter("MainMenu", 3f));
	}

	IEnumerator SwitchScenesAfter(string sceneName, float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}