using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBouncing : MonoBehaviour
{

    public PhysicMaterial bounce;

    private void Start()
    {
        FreezeRock();
    }


    public void FreezeRock()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        gameObject.GetComponent<Collider>().material = null;
    }

    public void UnfreezeRock()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<Collider>().material = bounce;
    }

}
