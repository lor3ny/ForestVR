using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawn;
    public Material startSkybox;
    private STATE state;

    public enum STATE
    {
        DAY,
        NIGHT,
        FIRE
    }

    private void Start()
    {
        SceneManager.LoadSceneAsync("Day", LoadSceneMode.Additive);
        RenderSettings.skybox = startSkybox;
        this.state = STATE.DAY;
        player.transform.position = spawn.position;
    }

    public STATE GetState()
    {
        return state;
    }

    public void SetState(STATE new_state)
    {
        this.state = new_state;
    }


}
