/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:              TeamSelectionScript.cs
/// Author:                Jack Kellett
/// Date Created:          15/12/2021
/// Brief:                 To select a team to use in the tourney mode.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamSelectionScript : MonoBehaviour {
	#region Private Variable Declarations.

	private static int currentTeamSelection = 0;
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void SelectTeam(int team)
	{
		currentTeamSelection = team;
	}

	public static int GetTeamSelection()
	{
		return currentTeamSelection;
	}
	#endregion
}
