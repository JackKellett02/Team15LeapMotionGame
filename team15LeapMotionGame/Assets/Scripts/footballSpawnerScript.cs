using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class footballSpawnerScript : MonoBehaviour {
	[SerializeField]
	BallForce ballController;
	//[SerializeField]
	//GameObject Spawner;
	private static bool isReset = false;
	private static bool playAgain = false;

	// Update is called once per frame
	void Start() {
		ballController.gameObject.SetActive(true);
	}

	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		ballController.gameObject.SetActive(true);
		gameObject.SetActive(false);

	}
}
