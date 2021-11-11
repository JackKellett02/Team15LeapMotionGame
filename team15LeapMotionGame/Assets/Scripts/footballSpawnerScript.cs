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
	void Start()
	{
		if (playAgain)
		{
			ballController.gameObject.SetActive(true);
			playAgain = false;
		}
	}
	void Update() {
		if (isReset) {
			ballController.gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (!isReset) {
			ballController.gameObject.SetActive(true);

		} else {
			isReset = false;
			playAgain = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

	public static void AllowReset() {
		isReset = true;
		Debug.Log("Now able to reset.");
	}

	public static bool GetIsReset() {
		return isReset;
	}
}
