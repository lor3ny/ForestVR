using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonHandler : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("Quit button pressed!");
        
        Application.Quit();
    }
}
