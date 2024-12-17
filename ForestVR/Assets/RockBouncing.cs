using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBouncing : MonoBehaviour
{

    public PhysicMaterial bounce;
    public AudioClip clip;

    public GameObject[] keypoints;

    int bounces = 0;

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
        for (int i = 0; i < keypoints.Length; i++)
        {
            keypoints[i].SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            if (bounces >= 3)
                return;
            GetComponent<AudioSource>().PlayOneShot(clip);
            bounces += 1;
        }
    }

}
