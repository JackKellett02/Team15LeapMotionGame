/////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:          GoalKeeperScript.cs
/// Author:            Jack Kellett
/// Date Created:      28/10/2021
/// Brief:             A goalkeeper that will move left and right to "defend" the goal.
/////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private Transform startPos = null;

	[SerializeField]
	private Transform endPos = null;

	[SerializeField]
	private float speed = 2.0f;
	#endregion

	#region Private Variable Declarations.
	private Vector3 targetPos = Vector3.zero;
	private float distanceToTargetPos = 0.0f;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		gameObject.transform.localPosition = startPos.localPosition;
		targetPos = endPos.localPosition;
	}

	// Update is called once per frame
	void Update() {
		distanceToTargetPos = CalculateDistanceToTarget();
		CheckDistanceToTarget();
		MoveTowardsTarget();
	}

	private float CalculateDistanceToTarget() {
		float dist = (targetPos - gameObject.transform.localPosition).magnitude;
		return dist;
	}

	private void CheckDistanceToTarget() {
		if (distanceToTargetPos <= 1.0f) {
			SwitchTargetPos();
		}
	}

	private void MoveTowardsTarget() {
		Vector3 dir = targetPos - gameObject.transform.localPosition;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.Self);
	}

	private void SwitchTargetPos() {
		if (targetPos == endPos.localPosition) {
			targetPos = startPos.localPosition;
		} else if (targetPos == startPos.localPosition) {
			targetPos = endPos.localPosition;
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
