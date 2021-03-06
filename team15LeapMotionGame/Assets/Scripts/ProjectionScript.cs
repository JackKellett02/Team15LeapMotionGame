using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields)
	[SerializeField]
	private LineRenderer lineRenderer = null;

	[SerializeField]
	private int numPoints = 50;

	[SerializeField]
	private float timeBetweenPoints = 0.1f;
	#endregion

	#region Private Variable Declarations.

	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		lineRenderer.gameObject.SetActive(false);
		Color tempColour = Color.black;
		tempColour.a = 0.0f;
		lineRenderer.endColor = tempColour;
		lineRenderer.startColor = tempColour;
	}

	// Update is called once per frame
	void Update() {
		if (fingerForce.GetProjectionState()) {
			if (fingerForce.GetFireState()) {
				lineRenderer.startColor = Color.green;
				lineRenderer.endColor = Color.green;
			} else {
				lineRenderer.startColor = Color.red;
				lineRenderer.endColor = Color.red;
			}
			lineRenderer.gameObject.SetActive(true);
			lineRenderer.positionCount = numPoints;
			List<Vector3> points = new List<Vector3>();
			Vector3 startingPosition = gameObject.transform.position;
			Vector3 startingVelocity = fingerForce.GetForceVector3();
			for (float t = 0.0f; t < numPoints; t += timeBetweenPoints) {
				Vector3 newPoint = startingPosition;
				newPoint.x += startingVelocity.x * t;
				newPoint.z += startingVelocity.z * t;
				newPoint.y += (startingVelocity.y * t + ((0.5f * (Physics.gravity.y) * (t * t)))) * 0.75f;
				points.Add(newPoint);
			}
			lineRenderer.SetPositions(points.ToArray());
		} else {
			lineRenderer.gameObject.SetActive(false);
		}

	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
