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

    private void Update()
    {
        countdown += Time.deltaTime;

        if (countdown>= maxCountDown)
        {
            Spawn();
            countdown = 0;
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
