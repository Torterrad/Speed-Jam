using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject HUD;
    public bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void resume()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        //Enable HUD
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        //Disable HUD
    }
}
