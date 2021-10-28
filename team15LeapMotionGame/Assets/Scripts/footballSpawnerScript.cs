using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footballSpawnerScript : MonoBehaviour
{
    [SerializeField]
    BallForce ballController;
    //[SerializeField]
    //GameObject Spawner;

    private void OnTriggerEnter(Collider other)
    {
        ballController.gameObject.SetActive(true);
        
    }
}
