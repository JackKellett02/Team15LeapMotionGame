////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       GroundScript.cs
/// Author:         Jack Kellett
/// Date Created:   12/10/2021
/// Brief:          Detects when the football has entered the ground and then adds to the miss counter.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {
	#region Private Functions.
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Football") {
			//Add to the miss counter.
			Debug.Log("Missed.");

			//Delete the football.
			Destroy(other.gameObject);
		}
	}
	#endregion
}
