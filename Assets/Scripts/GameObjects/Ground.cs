using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
	[SerializeField]
	GameObject tilePrefab;

	[SerializeField]
	GameObject treePrefab;

	void Awake() {
		//generate tiles
		const int size = 20;

		for (int i = -size; i <= size; i++) {
			for (int j = -size; j <= size; j++) {
				Instantiate(tilePrefab, new Vector3(i * 32, j * 32, 0), Quaternion.identity, transform);
			}
		}

		for (int i = 0; i < 50; i++) {
			GenerateTree(5, size);
		}

		for (int i = 0; i < 3; i++) {
			GenerateTree(2, 5);
		}
	}

	void GenerateTree(float near, float far) {
		//geenrate trees
		float direction = Random.Range(0, 360); //angle
		float distance = Random.Range(near, far); //H & A

		//SOH CAH TOA
		float sin = Mathf.Sin(direction * Mathf.PI / 180f);
		float cos = Mathf.Cos(direction * Mathf.PI / 180f);

		Instantiate(treePrefab, new Vector3(distance * cos * 32, distance * sin * 32, 0), Quaternion.identity, transform);
	}
}