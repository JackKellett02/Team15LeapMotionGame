////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       BallForce.cs
/// Author:         Harry Oldham
/// Date Created:   12/10/2021
/// Brief:          When the Ball comes into contact with the Player's hands, launches the ball forward 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RightHand")
        {
            m_Rigidbody.AddForce(transform.forward * m_Thrust);
            Debug.Log("Ball Hit");
        }
    }
}
