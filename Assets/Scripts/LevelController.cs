using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public float globalLightLevel = 1f;
	public float increment = 0f;

	void FixedUpdate() {
		globalLightLevel += increment;
		globalLightLevel = Mathf.Clamp(globalLightLevel, 0, 1);
	}
}