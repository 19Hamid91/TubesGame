using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public static GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         if(paused)
    //         {
    //             Resume();
    //         }
    //         else
    //         {
    //             Pause();
    //         }
    //     }
    // }

    public void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = 0;
        paused = true;
    }
    public void Resume()
    {
        Debug.Log("resume");
        Time.timeScale = 1;
        paused = false;
    }
}
