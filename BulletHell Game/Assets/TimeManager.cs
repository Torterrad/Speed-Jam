using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    public GameObject menuController;

    private void Update()
    {
        if (menuController.GetComponent<menuscript>().paused == false)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            
        }
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (menuController.GetComponent<menuscript>().paused == true)
        {
            Time.timeScale = 0f;

        }
    }

    public void SlowMo()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
