using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    GameObject manager;
    
    public int dmg;
    void Start()
    {
        player = GameObject.Find("Player");
        manager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == false)
            {
                other.GetComponent<PlayerController>().TakeDamage(dmg);
            }
            if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == false)
            {
                other.GetComponent<PlayerController>().TakeDamage(dmg);
            }
            if (this.tag == "BlueEnemy" && other.GetComponent<PlayerController>().isBlue == false)
            {
                other.GetComponent<PlayerController>().TakeDamage(dmg);
            }
            if (this.tag == "Enemy" )
            {
                other.GetComponent<PlayerController>().TakeDamage(dmg);
            }

            if (this.tag == "BlueEnemy" && other.GetComponent<PlayerController>().isBlue == true)
            {
                manager.GetComponent<ScoreSystem>().score += 10 * manager.GetComponent<ScoreSystem>().multiplier;
                //other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == true)
            {
                manager.GetComponent<ScoreSystem>().score += 10 * manager.GetComponent<ScoreSystem>().multiplier;
                //other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == true)
            {
                manager.GetComponent<ScoreSystem>().score += 10 * manager.GetComponent<ScoreSystem>().multiplier;
                //other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (this.tag == "BlueEnemy" && other.GetComponent<PlayerController>().isBlue == true)
            {
                
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == true)
            {
                
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == true)
            {
                
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
        }
    }
}
