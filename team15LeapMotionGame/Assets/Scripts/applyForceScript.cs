using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyForceScript : MonoBehaviour
{
	
	[SerializeField]
	private float force = 10.0f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Football")
		{
			Vector3 dirToFootball = other.gameObject.transform.position - gameObject.transform.position;
			dirToFootball.Normalize();
			dirToFootball = dirToFootball * force;
			Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
			rigidbody.AddForce(dirToFootball, ForceMode.Impulse);
			Debug.Log("hand hit");
		}
	}
}
