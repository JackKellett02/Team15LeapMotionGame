////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:        PauseScript.cs
/// Author:          Jack Kellett
/// Date Created:    09/12/2021
/// Brief:           To contain the functionality to pause the game whilst playing.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
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

	private AudioManagerScript audioManager;

	private bool canReturn = true;
	private bool canExit = true;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManagerScript>();
	}

	// Update is called once per frame
	void Update() {

	}

	private IEnumerator ReturnToMenu() {
		canReturn = false;
		yield return new WaitForSeconds(1.0f);
		//Load main menu scene.
		SceneManager.LoadScene(mainMenuSceneIndex);
	}

	private IEnumerator ExitTheGame() {
		canExit = false;
		yield return new WaitForSeconds(1.0f);
		//Quit Application.
		Application.Quit();
		Debug.Log("Application.Quit() called!!");
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void PauseGame() {
		//Pause all time related functionality.
		Time.timeScale = 0.0f;

		//Activate Pause UI and deactivate game UI.
		pauseUI.SetActive(true);
		gameUI.SetActive(false);

		//Stop Game Sounds and activate pause menu sounds.
		audioManager.StopAllSounds();
		audioManager.PlayPauseWhistleSound(false);
		audioManager.PlayLoopingPauseMusicSound(true);
	}

	public void ResumeGame() {
		//Resume all time related functionality.
		Time.timeScale = 1.0f;

		//Reactivate Game UI and deactivate pause UI.
		pauseUI.SetActive(false);
		gameUI.SetActive(true);

		//Stop All sounds and activate in game sounds.
		audioManager.StopAllSounds();
		audioManager.PlayPlayWhistleSound(false);
		audioManager.PlayInGameCrowdSound(true);
	}

	public void ReturnToMainMenu() {
		if (canReturn)
		{
			Time.timeScale = 1.0f;
			audioManager.PlayPauseWhistleSound(false);
			StartCoroutine("ReturnToMenu");
		}
	}

	public void ExitGame() {
		if (canExit)
		{
			Time.timeScale = 1.0f;
			audioManager.PlayPauseWhistleSound(false);
			StartCoroutine("ExitTheGame");
		}
	}
	#endregion
}
