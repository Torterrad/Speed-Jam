using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public int scoreIncrease;

    public int multiplier = 1;
    public int maxMultiplier = 4;
    public float multiplierTime;
    public float maxMultiplierTime =3f;

    public float scoreTime;
    public float maxScoreTime;

    public Text scoreText;
    public Text multiplierText;
    private void Start()
    {
        multiplierTime = maxMultiplierTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTime += Time.deltaTime;

        scoreText.text = score.ToString();
        multiplierText.text = multiplier.ToString() +"X";

        if (scoreTime >= maxScoreTime)
        {
            score += scoreIncrease * multiplier;
            scoreTime = 0;
        }
        if (multiplier<=1)
        {
            multiplier = 1;
            multiplierTime = maxMultiplierTime;
        }
        if (multiplier>= maxMultiplier)
        {
            multiplier = maxMultiplier;
        }
        if (multiplier >= 1)
        {
            multiplierTime -= Time.deltaTime;
            if (multiplierTime <= 0)
            {
                multiplier--;
                multiplierTime = maxMultiplierTime;
            }

        }
    }
}
