////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:        PauseScript.cs
/// Author:          Jack Kellett
/// Date Created:    09/12/2021
/// Brief:           To contain the functionality to pause the game whilst playing.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerialiseFields).
	[SerializeField]
	private int mainMenuSceneIndex = 0;

	[SerializeField]
	private GameObject gameUI;

	[SerializeField]
	private GameObject pauseUI;
	#endregion

	#region Private Variable Declarations.

	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void PauseGame() {
		//Pause all time related functionality.
		Time.timeScale = 0.0f;

		//Activate Pause UI and deactivate game UI.
		pauseUI.SetActive(true);
		gameUI.SetActive(false);
	}

	public void ResumeGame() {
		//Resume all time related functionality.
		Time.timeScale = 1.0f;

		//Reactivate Game UI and deactivate pause UI.
		pauseUI.SetActive(false);
		gameUI.SetActive(true);
	}

	public void ReturnToMainMenu() {
		//Load main menu scene.
		SceneManager.LoadScene(mainMenuSceneIndex);
	}

	public void ExitGame() {
		//Quit Application.
		Application.Quit();
		Debug.Log("Application.Quit() called!!");
	}
	#endregion
}
