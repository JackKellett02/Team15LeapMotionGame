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

	[SerializeField]
	private bool chaosMode = false;
	#endregion

	#region Private variable declarations.

	private AudioManagerScript audioManager;
	private float lastFingerDistance = float.MaxValue;
	private static Vector3 forceVector3 = Vector3.zero;
	private static Vector3 startingVelApprox = Vector3.zero;
	private static bool showProjection = false;
	private static bool canFire = false;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManagerScript>();
		forceVector3 = Vector3.zero;
		startingVelApprox = Vector3.zero;
		showProjection = false;
		canFire = false;
	}

	// Update is called once per frame
	void Update() {
		float distance = CalculateBoneDistance();
		float balldistance = CalculateBallDistance();
		if (lastFingerDistance <= minFingerDistance && (GameObject.FindGameObjectsWithTag("Football")[0].active)) {
			//Debug.Log("Last finger distance was less than the min finger distance.");
			//Debug.Log("Ball Distance: " + balldistance);
			CalculateForceVector3();
			CalculateVelocityVector3();
			if (balldistance <= maxBallDistance) {
				//Debug.Log("The ball distance was less than the max ball distance.");
				//Debug.Log("Finger Distance: " + distance);
				showProjection = true;
				canFire = true;
				if (distance > lastFingerDistance && distance > minFingerDistance) {
					Rigidbody rigidbody = football.gameObject.GetComponent<Rigidbody>();
					Vector3 randAddition = Vector3.zero;
					if (chaosMode) {
						randAddition = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
					}
					rigidbody.velocity = forceVector3 + randAddition;
					audioManager.PlayKickBallSound(false);
				}
			} else if (balldistance <= (maxBallDistance * 2)) {
				showProjection = true;
				canFire = false;
			} else {
				showProjection = false;
			}
		} else {
			showProjection = false;
		}

		lastFingerDistance = distance;
	}

	private void CalculateForceVector3() {
		Vector3 dirToFootball = football.gameObject.transform.position - handGameObject.transform.position;
		dirToFootball.y += GetYDirForce();
		dirToFootball.Normalize();
		dirToFootball = dirToFootball * force;
		forceVector3 = dirToFootball;
	}

	private void CalculateVelocityVector3() {
		Vector3 force = forceVector3;
		//force.y -= 9.81f;

		startingVelApprox = 0.5f * (force * Time.deltaTime);
	}

	private float CalculateBoneDistance() {
		return (thumbBone.transform.position - indexBone.transform.position).magnitude;
	}

	private float CalculateBallDistance() {
		return (football.transform.position - handGameObject.transform.position).magnitude;
	}

	private float GetYDirForce() {
		Vector3 rotationVector3 = handGameObject.transform.eulerAngles;
		if (rotationVector3.x > 100.0f) {
			float xTemp = 360 - rotationVector3.x;
			rotationVector3.x = 0.0f - xTemp;
		}
		float temp = (rotationVector3.x / 100.0f) * upForceMultipler;
		return temp;
	}
	#endregion

	#region Public Access Functions(Getters and Setters).

	public static Vector3 GetForceVector3() {
		return forceVector3;
	}

	public static Vector3 GetStartingVelocity() {
		return startingVelApprox;
	}

	public static bool GetProjectionState() {
		return showProjection;
	}

	public static bool GetFireState() {
		return canFire;
	}
	#endregion
}
