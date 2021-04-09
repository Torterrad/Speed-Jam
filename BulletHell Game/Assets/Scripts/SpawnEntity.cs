using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public float countdown = 0;
    public float maxCountDown;

    public float enemyForce;
    public float maxEnemyForce;
    public float enemyForceIncrease;

    public float timer;
    public float timeInterval;

    public float playerSpeedIncrease;
    public float maxPlayerSpeed;

    public GameObject player;
    public bool playerDead = false;

    private void Update()
    {
        countdown += Time.deltaTime;

        timer += Time.deltaTime;

        if (countdown>= maxCountDown)
        {
            Spawn();
            countdown = 0;
        }
        if (timer >= 5)
        {
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
    }

    void Spawn()
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = enemyTypes[Random.Range(0, spawnPoints.Length)];

       GameObject newEnemy = Instantiate(enemy, sp.position, sp.rotation);

        Rigidbody2D rb = newEnemy.GetComponent<Rigidbody2D>();
        rb.AddForce(sp.up * enemyForce, ForceMode2D.Impulse);
    }
}
