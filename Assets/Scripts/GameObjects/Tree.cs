using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		spriteRenderer.sortingOrder = -(int)Mathf.Floor(transform.localPosition.y * 100);
	}
}