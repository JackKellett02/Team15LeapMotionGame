using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalMover : MonoBehaviour {
	GameObject target;
	Vector3 startPos;
	GameObject targetPlane;

	int counter = 1;

	[SerializeField]
	GameObject GoalObject;

	[SerializeField]
	float goalMovement = 2.0f;

	[SerializeField]
	private bool chaosMode = false;

	private float difference = 0.0f;


	private void Start() {
		startPos = transform.position;
		difference = transform.position.z - GoalObject.transform.position.z;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Football") {
			if (chaosMode) {
				counter += Random.Range(-1, 1);
				counter = Mathf.Clamp(counter, 1, 5);
			} else {
				counter++;
			}


			Vector3 goalPos = new Vector3(-0.37f, -0.181f, 5.39f);
			goalPos.z += goalMovement * counter;
			GoalObject.transform.position = goalPos;

			Vector3 position = new Vector3(Random.Range(-1.687f, 1.021f), Random.Range(-0.535f, 0.07f), goalPos.z + difference);
			transform.position = position;


		}

	}


	// Update is called once per frame
	void Update() {

	}
}
