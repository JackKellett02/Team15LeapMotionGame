////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       ScoreScript.cs
/// Author:         Chris Johnson
/// Date Created:   12/10/2021
/// Brief:  All functions relating to the score
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// All functions relating to the score
/// </summary>
public class ScoreScript : MonoBehaviour {
	//SerializeFields

	//prefabs for the scoreboard ui elements
	[SerializeField]
	GameObject UIfootballPrefab;
	[SerializeField]
	GameObject UICrossPrefab;
	[SerializeField]
	GameObject UITickPrefab;

	[SerializeField]
	private int m_shotsMax = 5; //maximum number of shots that can be taken

	[SerializeField]
	private float score_scale = 1; //scale of score //move to use ui scale ? editiable though options

	[SerializeField]
	private float finishTime = 3.0f;

	//private
	private int m_shots;
	private int m_goalsScored;

	private GameObject[] UI_FootBall;
	private GameObject[] UI_Tick;
	private GameObject[] UI_Cross;

	private bool allowReset = true;
	//public
	#region gets/sets

	public int Shots {
		get { return m_shots; }
	}
	public int GoalsScored {
		get { return m_goalsScored; }

	}
	#endregion

	/// <summary> - Call this on goal score - 
	/// update stored score and displayed score
	/// </summary>
	public void GoalScored() {
		m_shots++;
		m_goalsScored++;

		UI_Cross[m_shots - 1].SetActive(false);
		UI_Tick[m_shots - 1].SetActive(true);

	}

	/// <summary>
	/// 
	/// </summary>
	public void GoalMissed() {
		m_shots++;

		UI_Cross[m_shots - 1].SetActive(true);
		UI_Tick[m_shots - 1].SetActive(false);

	}

	/// <summary>
	/// 
	/// </summary>
	public void ResetScore() {
		m_shots = 0;
		foreach (GameObject go in UI_Cross) {
			go.SetActive(false);
		}
		foreach (GameObject go in UI_Tick) {
			go.SetActive(false);
		}
	}


	// Start is called before the first frame update
	void Start() {
		UI_FootBall = new GameObject[m_shotsMax];
		UI_Cross = new GameObject[m_shotsMax];
		UI_Tick = new GameObject[m_shotsMax];

		//get ball prefabs width - creates gets destroys - not great method
		//GameObject ballPrefab = Instantiate(UIfootballPrefab);
		//ballPrefab.transform.localScale = new Vector3(score_scale, score_scale, score_scale);
		//RectTransform rtBall = (RectTransform)UIfootballPrefab.transform;
		//float ballWidth = rtBall.rect.width;
		//Destroy(ballPrefab);


		Vector3 UI_ScaleVector = new Vector3(score_scale, score_scale, score_scale);

		//Instantiate all of the score ui elements
		for (int i = 0; i < m_shotsMax; i++) {
			UI_FootBall[i] = Instantiate(UIfootballPrefab, new Vector3((((50 * score_scale) * 2) * i) + (50 * score_scale), 50 * score_scale, 0), Quaternion.identity);
			UI_FootBall[i].transform.SetParent(gameObject.transform);
			UI_FootBall[i].transform.localScale = UI_ScaleVector;
			UI_FootBall[i].SetActive(false);

			UI_Cross[i] = Instantiate(UICrossPrefab, new Vector3((((50 * score_scale) * 2) * i) + (50 * score_scale), 50 * score_scale, 0), Quaternion.identity);
			UI_Cross[i].transform.SetParent(gameObject.transform);
			UI_Cross[i].transform.localScale = UI_ScaleVector;
			UI_Cross[i].SetActive(false);

			UI_Tick[i] = Instantiate(UITickPrefab, new Vector3((((50 * score_scale) * 2) * i) + (50 * score_scale), 50 * score_scale, 0), Quaternion.identity);
			UI_Tick[i].transform.SetParent(gameObject.transform);
			UI_Tick[i].transform.localScale = UI_ScaleVector;
			UI_Tick[i].SetActive(false);
		}

		//temp set active
		//needs to be moved later
		foreach (GameObject go in UI_FootBall) {
			go.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update() {
		if (m_shots >= m_shotsMax) {
			//Reset levels.
			if (allowReset) {
				allowReset = false;
				StartCoroutine("ResetTimer");
			}
		}
	}

	private IEnumerator ResetTimer() {
		yield return new WaitForSeconds(finishTime);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
