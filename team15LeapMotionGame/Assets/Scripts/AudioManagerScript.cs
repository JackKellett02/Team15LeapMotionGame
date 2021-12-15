////////////////////////////////////////////////////////////////////////////////////
/// Filename:       AudioManagerScript.cs
/// Author:         Jack Kellett
/// Date Created:   13/12/2021
/// Brief:          To contain all functions required to play different audio files.
////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).

	[SerializeField]
	private GameObject goalMissed = null;

	[SerializeField]
	private GameObject goalPostCollision = null;

	[SerializeField]
	private GameObject goalScored = null;

	[SerializeField]
	private GameObject inGameCrowd = null;

	[SerializeField]
	private GameObject keeperSave = null;

	[SerializeField]
	private GameObject kickBall = null;

	[SerializeField]
	private GameObject loopingMenuMusic = null;

	[SerializeField]
	private GameObject loopingMenuMusic2 = null;

	[SerializeField]
	private GameObject loopingPauseMusic = null;

	[SerializeField]
	private GameObject pauseWhistle = null;

	[SerializeField]
	private GameObject playWhistle = null;

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

	private IEnumerator RestartIngameCrowd(float time) {
		yield return new WaitForSeconds(time / 2.0f);
		PlayInGameCrowdSound(true);
	}

	#endregion

	#region Public Access Functions (Getters and Setters).

	public void PlayGoalMissedSound(bool looped) {
		goalMissed.SetActive(false);
		goalMissed.SetActive(true);
		goalMissed.GetComponent<AudioSource>().loop = looped;

		//Set timer to restart ingame sound.
		float timer = goalScored.GetComponent<AudioSource>().clip.length;
		timer = timer / 2.0f;
		StartCoroutine(RestartIngameCrowd(timer));
	}
	public void StopGoalMissedSound() {
		goalMissed.SetActive(false);
	}

	public void PlayGoalPostCollisionSound(bool looped) {
		goalPostCollision.SetActive(false);
		goalPostCollision.SetActive(true);
		goalPostCollision.GetComponent<AudioSource>().loop = looped;
	}

	public void StopGoalPostCollisionSound() {
		goalPostCollision.SetActive(false);
	}

	public void PlayGoalScoredSound(bool looped) {
		goalScored.SetActive(false);
		goalScored.SetActive(true);
		goalScored.GetComponent<AudioSource>().loop = looped;

		//Set timer to restart ingame sound.
		float timer = goalScored.GetComponent<AudioSource>().clip.length;
		StartCoroutine(RestartIngameCrowd(timer));
	}

	public void StopGoalScoredSound() {
		goalScored.SetActive(false);
	}

	public void PlayInGameCrowdSound(bool looped) {
		inGameCrowd.SetActive(false);
		inGameCrowd.SetActive(true);
		inGameCrowd.GetComponent<AudioSource>().loop = looped;
	}

	public void StopInGameCrowdSound() {
		inGameCrowd.SetActive(false);
	}

	public void PlayKeeperSaveSound(bool looped) {
		keeperSave.SetActive(false);
		keeperSave.SetActive(true);
		keeperSave.GetComponent<AudioSource>().loop = looped;
	}

	public void StopKeeperSaveSound() {
		keeperSave.SetActive(false);
	}

	public void PlayKickBallSound(bool looped) {
		kickBall.SetActive(false);
		kickBall.SetActive(true);
		kickBall.GetComponent<AudioSource>().loop = looped;
	}

	public void StopKickBallSound() {
		kickBall.SetActive(false);
	}

	public void PlayLoopingMenuMusicSound(bool looped) {
		loopingMenuMusic.SetActive(false);
		loopingMenuMusic.SetActive(true);
		loopingMenuMusic.GetComponent<AudioSource>().loop = looped;
	}

	public void StopLoopingMenuMusicSound() {
		loopingMenuMusic.SetActive(false);
	}

	public void PlayLoopingMenuMusic2Sound(bool looped) {
		loopingMenuMusic2.SetActive(false);
		loopingMenuMusic2.SetActive(true);
		loopingMenuMusic2.GetComponent<AudioSource>().loop = looped;
	}

	public void StopLoopingMenuMusic2Sound() {
		loopingMenuMusic2.SetActive(false);
	}

	public void PlayLoopingPauseMusicSound(bool looped) {
		loopingPauseMusic.SetActive(false);
		loopingPauseMusic.SetActive(true);
		loopingPauseMusic.GetComponent<AudioSource>().loop = looped;
	}

	public void StopLoopingPauseMusicSound() {
		loopingPauseMusic.SetActive(false);
	}

	public void PlayPauseWhistleSound(bool looped) {
		pauseWhistle.SetActive(false);
		pauseWhistle.SetActive(true);
		pauseWhistle.GetComponent<AudioSource>().loop = looped;
	}

	public void StopPauseWhistleSound() {
		pauseWhistle.SetActive(false);
	}

	public void PlayPlayWhistleSound(bool looped) {
		playWhistle.SetActive(false);
		playWhistle.SetActive(true);
		playWhistle.GetComponent<AudioSource>().loop = looped;
	}

	public void StopPlayWhistleSound() {
		playWhistle.SetActive(false);
	}

	public void StopAllSounds() {
		StopGoalMissedSound();
		StopGoalPostCollisionSound();
		StopGoalScoredSound();
		StopInGameCrowdSound();
		StopKeeperSaveSound();
		StopKickBallSound();
		StopLoopingMenuMusicSound();
		StopLoopingMenuMusic2Sound();
		StopLoopingPauseMusicSound();
		StopPauseWhistleSound();
		StopPlayWhistleSound();
	}
	#endregion
}
