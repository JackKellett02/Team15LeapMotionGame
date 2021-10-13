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
    GameObject footBall;
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }


  
}
