////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       GoalScript.cs
/// Author:         Jack Kellett
/// Date Created:   12/10/2021
/// Brief:          Detects when the football has entered the goal and then adds to the score.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	[SerializeField]
	BallForce ballController;
	#region Private Functions.
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Football") {
			//Add to the score.
			Debug.Log("Goal Scored.");
			ScoreScript scoreScript = GameObject.FindGameObjectsWithTag("ScoreObject")[0].GetComponent<ScoreScript>();
			scoreScript.GoalScored();

			//Delete the football.
			//Destroy(other.gameObject);
			ballController.gameObject.transform.position = ballController.startPos;
			Rigidbody temp = ballController.gameObject.GetComponent<Rigidbody>();
			temp.velocity = Vector3.zero;
			temp.angularVelocity = Vector3.zero;
		}
	}
	#endregion
}
