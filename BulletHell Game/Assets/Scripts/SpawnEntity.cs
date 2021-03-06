using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public float countdown = 0;
    public float maxCountDown;

    public float randomMinimumValue;
    public float randomMaximumValue;

    public float randomMinimumValueLock;
    public float randomMaximumValueLock;

    public bool minValueReached = false;
    public bool maxValueReached = false;

    public float enemyForce;
    public float maxEnemyForce;
    public float enemyForceIncrease;

    public float timer;
    public float timeInterval;

    public float playerSpeedIncrease;
    public float maxPlayerSpeed;

    public GameObject player;
    public bool playerDead = false;

    private void Start()
    {
        maxCountDown = Random.Range(randomMinimumValue,randomMaximumValue);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        countdown += Time.deltaTime;

        timer += Time.deltaTime;

        if (countdown>= maxCountDown)
        {
            Spawn();
            maxCountDown = Random.Range(randomMinimumValue, randomMaximumValue);
            
            countdown = 0;
        }
        if (timer >= 5)
        {
            if (!minValueReached)
            {
                randomMinimumValue -= 0.1f;
            }
            if (!maxValueReached)
            {
                randomMaximumValue -= 0.1f;
            }
            if (playerDead)
            {
                enemyForce += enemyForceIncrease;
                
            }

            else
            {
                enemyForce += enemyForceIncrease;
                player.GetComponent<PlayerController>().speed += playerSpeedIncrease;
            }
            timer = 0;
        }
        if (timer >= 5.1)
        {
            player.GetComponent<PlayerController>().speed += playerSpeedIncrease;
            timer = 0;
        }
        
        if (enemyForce>= maxEnemyForce)
        {
            enemyForce = maxEnemyForce;
        }
        if(player.GetComponent<PlayerController>().speed >= maxPlayerSpeed)
        {
            player.GetComponent<PlayerController>().speed = maxPlayerSpeed;
        }
        if (randomMaximumValue <= randomMaximumValueLock)
        {
            maxValueReached = true;
            randomMaximumValue = randomMaximumValueLock;
        }
        if (randomMinimumValue <= randomMinimumValueLock)
        {
            minValueReached = true;
            randomMinimumValue = randomMinimumValueLock;
        }
    }

    void Spawn()
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = enemyTypes[Random.Range(0, enemyTypes.Length)];

       GameObject newEnemy = Instantiate(enemy, sp.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        Rigidbody2D rb = newEnemy.GetComponent<Rigidbody2D>();
        rb.AddForce(sp.up * enemyForce, ForceMode2D.Impulse);
    }
}
