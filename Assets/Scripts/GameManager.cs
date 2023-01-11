using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Data.score = 0;
        Data.gem = 0;
        Data.lastScore = 0;
        Data.lastScore = 0;
        Data.lastGem = 0;
        Data.paused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
