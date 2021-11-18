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
	private GameObject handGameObject = null;
	[SerializeField]
	private float maxBallDistance = 1.0f;
	[SerializeField]
	GameObject indexBone;
	[SerializeField]
	GameObject thumbBone;
	[SerializeField]
	float fingerDistance = 0.01f;
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
		Debug.Log("Finger Distance: " + distance);
		Debug.Log("Ball Distance: " + balldistance);
		//if (lastFingerDistance <= fingerDistance) {
		//	if (balldistance <= maxBallDistance) {
		//		if (distance > lastFingerDistance) {
		//			Vector3 dirToFootball = football.gameObject.transform.position - gameObject.transform.position;
		//			dirToFootball.Normalize();
		//			dirToFootball = dirToFootball * force;
		//			Rigidbody rigidbody = football.gameObject.GetComponent<Rigidbody>();
		//			rigidbody.AddForce(dirToFootball, ForceMode.Impulse);
		//			Debug.Log("Flicked! space between fingers was: " + distance);
		//		}
		//	}
		//}

		lastFingerDistance = distance;
	}

	private float CalculateBoneDistance() {
		return (thumbBone.transform.position - indexBone.transform.position).magnitude;
	}

	private float CalculateBallDistance() {
		return (football.transform.position - handGameObject.transform.position).magnitude;
	}
	#endregion

	#region Public Access Functions(Getters and Setters).

	#endregion
}
