using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingerForce : MonoBehaviour {
	#region Variables to apply via the unity inspector (SerializeFields).
	[SerializeField]
	GameObject football;
	[SerializeField]
	private float force = 10.0f;
	[SerializeField]
	private float upForceMultipler = 1.0f;
	[SerializeField]
	private GameObject handGameObject = null;
	[SerializeField]
	private float maxBallDistance = 1.0f;
	[SerializeField]
	GameObject indexBone;
	[SerializeField]
	GameObject thumbBone;
	[SerializeField]
	float minFingerDistance = 0.03f;
	#endregion

	#region Private variable declarations.

	private float lastFingerDistance = float.MaxValue;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		float distance = CalculateBoneDistance();
		float balldistance = CalculateBallDistance();
		if (lastFingerDistance <= minFingerDistance) {
			//Debug.Log("Last finger distance was less than the min finger distance.");
			//Debug.Log("Ball Distance: " + balldistance);
			if (balldistance <= maxBallDistance) {
				//Debug.Log("The ball distance was less than the max ball distance.");
				//Debug.Log("Finger Distance: " + distance);
				if (distance > lastFingerDistance && distance > minFingerDistance) {
					Vector3 dirToFootball = football.gameObject.transform.position - handGameObject.transform.position;
					dirToFootball.y += GetYDirForce();
					dirToFootball.Normalize();
					dirToFootball = dirToFootball * force;
					Rigidbody rigidbody = football.gameObject.GetComponent<Rigidbody>();
					rigidbody.AddForce(dirToFootball, ForceMode.Impulse);
					Debug.Log("Flicked! space between fingers was: " + distance);
				}
			}
		}

		lastFingerDistance = distance;
	}

	private float CalculateBoneDistance() {
		return (thumbBone.transform.position - indexBone.transform.position).magnitude;
	}

	private float CalculateBallDistance() {
		return (football.transform.position - handGameObject.transform.position).magnitude;
	}

	private float GetYDirForce()
	{
		Vector3 rotationVector3 = handGameObject.transform.eulerAngles;
		if (rotationVector3.x > 100.0f)
		{
			float xTemp = 360 - rotationVector3.x;
			rotationVector3.x = 0.0f - xTemp;
		}
		float temp = (rotationVector3.x / 100.0f) * upForceMultipler;
		Debug.Log("X Rotation: " + rotationVector3.x);
		Debug.Log("Ammount to go up: " + temp);
		return temp;
	}
	#endregion

	#region Public Access Functions(Getters and Setters).

	#endregion
}
