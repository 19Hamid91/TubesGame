using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = 0;
        Data.paused = true;
        PausePanel.SetActive(true);
    }
    public void Resume()
    {
        Debug.Log("resume");
        Time.timeScale = 1;
        Data.paused = false;
        PausePanel.SetActive(false);
    }
}
