using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menuscript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject HUD;
    public GameObject loseMenu;
    public GameObject GameHandler;
   
    public Text scoreText;

    public int score;

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
        Time.timeScale = 1f;
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
        pauseMenu.GetComponent<Animator>().Play("PauseAnim");
    }
    public void gameOver()
    {
        ScreenShakeController.instance.StartShake(0f, 1f);
        score = GameHandler.GetComponent<ScoreSystem>().score;
        HUD.SetActive(false);
        loseMenu.SetActive(true);
        Time.timeScale = 0;

        scoreText.text = "Score: " + score.ToString();

        loseMenu.GetComponent<Animator>().Play("LossAnim");
        //Play UI animation 
    }
}
