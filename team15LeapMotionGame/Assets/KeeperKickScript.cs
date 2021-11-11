/////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:         KeeperKickScript.cs
/// Author:           Jack Kellett
/// Date Created:     11/11/2021
/// Brief:            To allow the keeper to add force to the ball when the ball hits the keeper.
/////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperKickScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private float force = 10.0f;
	#endregion

	#region Private Functions.
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Football") {
			Vector3 dirToFootball = other.gameObject.transform.position - gameObject.transform.position;
			dirToFootball.Normalize();
			dirToFootball = dirToFootball * force;
			Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
			rigidbody.AddForce(dirToFootball, ForceMode.Impulse);
			Debug.Log("Keeper kicked ball.");
		}
	}
	#endregion
}
