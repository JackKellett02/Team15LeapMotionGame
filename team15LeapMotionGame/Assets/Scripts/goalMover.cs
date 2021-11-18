using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalMover : MonoBehaviour
{
    GameObject target;
    //void targetSpawn()
    //{
    //    Vector3 position = new Vector3(Random.Range(-2.303f, 1.446f),Random.Range(-0.878f, 0.557f), (5.015f));
    //    Instantiate(target, position, Quaternion.identity);
    //}
    Vector3 startPos;
    GameObject targetPlane;

  

    private void Start()
    {
        startPos = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Football")
        {
            Vector3 position = new Vector3(Random.Range(-1.687f, 1.021f), Random.Range(-0.535f, 0.07f), startPos.z);
            transform.position = position;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
