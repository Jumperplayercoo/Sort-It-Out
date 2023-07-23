using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour
{
    public GameObject GameWonUI;
    public bool paused = false;

    public void Pause()
    {
        GameWonUI.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    void Resume()
    {
        GameWonUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Resume();
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenu");
    }
}
