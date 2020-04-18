using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public float globalLightLevel = 1f;
	public float increment = 0f;

	public int globalWood = 0;

	void FixedUpdate() {
		globalLightLevel += increment;
		globalLightLevel = Mathf.Clamp(globalLightLevel, 0, 1);

		if (globalLightLevel == 0) {
			SceneManager.LoadScene("FireGoesOut");
		}
	}
}