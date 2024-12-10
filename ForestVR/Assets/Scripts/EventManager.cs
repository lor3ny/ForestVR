using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    public string sceneToLoad;
    [SerializeField]
    public string sceneToUnload;
    public SystemManager.STATE loadState;
    public SystemManager.STATE unloadState;

    public Material loadSkybox;
    private SystemManager system;

    public GameObject counterTrigger;
    public bool imActive;

    private void Start()
    {
        system = GameObject.Find("SystemManager").GetComponent<SystemManager>();
        if (imActive)
        {
            counterTrigger.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (system.GetState() != unloadState)
        {
            Debug.LogError("Uncoherent State!");
            return;
        }

        system.SetState(loadState);

        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneToUnload);
        RenderSettings.skybox = loadSkybox;
        if (loadState == SystemManager.STATE.FIRE)
        {
            RenderSettings.fog = true;
        } else
        {
            RenderSettings.fog = false;
        }

        counterTrigger.SetActive(true);

        Debug.Log(sceneToUnload + " Scene Loaded!");
    }
}
