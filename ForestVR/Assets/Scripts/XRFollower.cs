using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRFollower : MonoBehaviour
{

    public Transform xrTransfrom;

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector3(xrTransfrom.position.x, xrTransfrom.position.y, xrTransfrom.position.z);
        Vector3 targetRotation = gameObject.transform.rotation.eulerAngles;
        targetRotation.y = xrTransfrom.eulerAngles.y;
        gameObject.transform.eulerAngles = targetRotation;
    }
}
