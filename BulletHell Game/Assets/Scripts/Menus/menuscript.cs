using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menuscript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject lossMenu;
    public GameObject HUD;
    public GameObject GameHandler;

    public Text scoreText;

    public int score;

    public static bool paused = false;

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

        if (GameHandler.GetComponent<SpawnEntity>().playerDead == true)
        {
            gameOver();
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

    public void gameOver()
    {
        score = GameHandler.GetComponent<ScoreSystem>().score;
        HUD.SetActive(false);

        //Time.timeScale = 0;

        scoreText.text = score.ToString();

        lossMenu.SetActive(true);
        //Play UI animation 
    }
}
