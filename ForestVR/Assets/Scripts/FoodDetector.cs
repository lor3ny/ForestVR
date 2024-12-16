using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDetector : MonoBehaviour
{

    public ParticleSystem particle;

    public AudioClip eat;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Debug.Log("Food captured");
            particle.Play();
            source.PlayOneShot(eat);
            //Animal happy
        }
    }
}
