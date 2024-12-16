using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour
{

    public bool isPaper;
    public bool isPlastic;
    public bool isElectronic;


    public AudioClip trash;
    private AudioSource trashSource;

    private void Start()
    {
        trashSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (isPaper)
        {
            if (other.CompareTag("TrashPlastic"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash plastic captured");
                trashSource.PlayOneShot(trash);
            }
        }

        if (isElectronic)
        {
            if (other.CompareTag("TrashPaper"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash paper captured");
                trashSource.PlayOneShot(trash);
            }
        }


        if (isPlastic)
        {
            if (other.CompareTag("TrashElectronics"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash electronic captured");
                trashSource.PlayOneShot(trash);
            }
        }
    }
}
