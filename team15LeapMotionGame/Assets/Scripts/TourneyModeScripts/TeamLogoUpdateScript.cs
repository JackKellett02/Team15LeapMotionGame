/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:                   TeamLogoUpdateScript.cs
/// Author:                     Jack Kellett
/// Date Created:               15/12/2021
/// Brief:                      To update the team logo shown to the player.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogoUpdateScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private bool isKeeper = false;

	[SerializeField]
	private List<GameObject> logos = new List<GameObject>();
	#endregion

	#region Private Variable Declarations.
	private int previousSelection = 0;
	private int selection = 0;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		if (isKeeper) {
			selection = Random.Range(0, logos.Count * 1);
			if (selection == TeamSelectionScript.GetTeamSelection()) {
				selection++;
			}
		}
	}

	// Update is called once per frame
	void Update() {
		if (!isKeeper) {
			selection = TeamSelectionScript.GetTeamSelection();
		}

		if (selection != previousSelection) {
			DeactivateAllLogos();
			ActivateLogoWithIndex(selection);
			previousSelection = selection;
		}
	}

	private void DeactivateAllLogos() {
		for (int i = 0; i < logos.Count; i++) {
			logos[i].SetActive(false);
		}
	}

	private void ActivateLogoWithIndex(int index) {
		logos[index].SetActive(true);
	}
	#endregion
}
