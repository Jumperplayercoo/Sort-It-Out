using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverUI;
    public bool paused = false;

    public void Pause() 
    {
        GameOverUI.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    void Resume()
    {
        GameOverUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Resume();
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Resume();
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenu");
    }
}
