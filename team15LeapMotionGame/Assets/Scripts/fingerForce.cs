using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingerForce : MonoBehaviour
{
    [SerializeField]
    GameObject indexBone;
    [SerializeField]
    GameObject thumbBone;
    [SerializeField]
    GameObject football;
    [SerializeField]
    float fingerDistance = 0.01f;
    [SerializeField]
    GameObject handObject;
    [SerializeField]
    private float force = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = calculateBonedistance();
        float balldistance = calculateBalldistance();
        //Debug.Log("Distance of fingers: " + distance);
        if (distance <= fingerDistance)
        {
            if(distance < balldistance)
            {
                if(distance > 0.1f)
                {
                    Vector3 dirToFootball = football.gameObject.transform.position - gameObject.transform.position;
                    dirToFootball.Normalize();
                    dirToFootball = dirToFootball * force;
                    Rigidbody rigidbody = football.gameObject.GetComponent<Rigidbody>();
                    rigidbody.AddForce(dirToFootball, ForceMode.Impulse);
                    Debug.Log("Flicked! space between fingers was: " + distance);
                }
            }
        }

    }

    private float calculateBonedistance()
    {
        return (thumbBone.transform.position - indexBone.transform.position).magnitude;
    }

    private float calculateBalldistance()
    {
        return (football.transform.position - indexBone.transform.position).magnitude;
    }
}
