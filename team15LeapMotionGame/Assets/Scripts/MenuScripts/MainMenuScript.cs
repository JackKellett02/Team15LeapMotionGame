////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:           MainMenuScript.cs
/// Author:             Jack Kellett
/// Date Created:       13/12/2021
/// Brief:              To contain all functionality to allow the player to navigate through game modes.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]

	#endregion

	#region Private Variable Declarations.

	private AudioManagerScript audioManager;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManagerScript>();
		audioManager.PlayLoopingMenuMusicSound(true);
	}

	// Update is called once per frame
	void Update() {

	}

	private IEnumerator LoadGameScene(string sceneToLoad, float timeToWait) {
		yield return new WaitForSeconds(timeToWait);
		SceneManager.LoadScene(sceneToLoad);
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void QuickStartModeBegin() {
		StartCoroutine(LoadGameScene("HandTrackerScene", 0.5f));
	}

	public void QuitGame() {
		Application.Quit();
		Debug.Log("Application.Quit() has been called.");
	}
	#endregion
}
