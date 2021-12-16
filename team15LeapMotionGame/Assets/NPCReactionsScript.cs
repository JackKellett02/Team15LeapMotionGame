/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:            NPCReactionsScript.cs
/// Author:              Jack Kellett
/// Date Created:        16/12/2021
/// Brief:               To make npcs move when a goal is scored.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;

public class NPCReactionsScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerialiseFields).
	[SerializeField]
	private float movementUpDown = 10.0f;

	[SerializeField]
	private float movementSpeed = 10.0f;

	[SerializeField]
	private float switchTime = 1.0f;

	[SerializeField]
	private List<GameObject> npcGroups;
	#endregion

	#region Private Variable Declarations.

	private List<Vector3> startPosList = new List<Vector3>();
	private List<Vector3> endPosList = new List<Vector3>();
	private bool goToEndPos = true;
	private static bool isReacting = false;

	private float timer = 0.0f;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		isReacting = false;


		for (int i = 0; i < npcGroups.Count; i++) {
			startPosList.Add(Vector3.zero);
			endPosList.Add(Vector3.zero);
			startPosList[i] = npcGroups[i].transform.position;
			Vector3 endPos = npcGroups[i].transform.position;
			if (i == 2) {
				endPos.y -= movementUpDown;
			} else {
				endPos.y += movementUpDown;
			}

			endPosList[i] = endPos;
		}
	}

	// Update is called once per frame
	void Update() {
		if (isReacting) {
			//Update Target.
			timer += Time.deltaTime;
			if (timer >= switchTime) {
				timer = 0.0f;
				goToEndPos = !goToEndPos;
			}

			//Move towards target.
			for (int i = 0; i < npcGroups.Count; i++) {
				Vector3 tempPos = npcGroups[i].transform.position;
				Vector3 dirToTarget = new Vector3();
				if (goToEndPos) {
					dirToTarget = endPosList[i] - tempPos;
					dirToTarget.Normalize();
				} else {
					dirToTarget = startPosList[i] - tempPos;
					dirToTarget.Normalize();
				}

				tempPos += (dirToTarget * movementSpeed * Time.deltaTime);
				npcGroups[i].transform.position = tempPos;
			}
		} else {
			for (int i = 0; i < npcGroups.Count; i++) {
				npcGroups[i].transform.position = startPosList[i];
			}
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public static void NPCReactions(bool react) {
		isReacting = react;
	}
	#endregion
}
