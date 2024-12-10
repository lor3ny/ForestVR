using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour
{

    public bool isPaper;
    public bool isPlastic;
    public bool isElectronic;


    private void OnTriggerEnter(Collider other)
    {

        if (isPaper)
        {
            if (other.CompareTag("TrashPlastic"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash plastic captured");
            }
        }

        if (isElectronic)
        {
            if (other.CompareTag("TrashPaper"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash paper captured");
            }
        }


        if (isPlastic)
        {
            if (other.CompareTag("TrashElectronics"))
            {
                Destroy(other.gameObject);
                Debug.Log("Trash electronic captured");
            }
        }
    }
}
