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
    }
}
