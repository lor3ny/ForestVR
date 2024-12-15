using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class FireInteractor : MonoBehaviour
{ 

    [SerializeField]
    public bool isOn;

    public bool isActivator;

    private void Start()
    {
        if (isOn)
            GetComponentInChildren<ParticleSystem>().Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire")){
            if (other.GetComponent<FireInteractor>().IsOn())
            {
                StartLighting();
                if (isActivator)
                {
                    Activation();
                }
            }
        }
    }

    private void StartLighting()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        isOn = true;
    }

    public bool IsOn()
    {
        return isOn;
    }

    private void Activation()
    {
        // Activate animation of the door
        GameObject.Find("DoorDayNight").GetComponent<Animator>().SetTrigger("ActivateDoor");
    }
}
