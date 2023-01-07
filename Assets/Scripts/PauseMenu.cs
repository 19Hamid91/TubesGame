using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Data.paused = false;
        Time.timeScale = 1;
        Data.score = Data.lastScore;
        Data.gem = Data.lastGem;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
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
