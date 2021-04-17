using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public AudioSource click;
    public AudioSource trans;

    public float transitionTime;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        click.Play();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Quit()
    {
        click.Play();
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        trans.Play();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
