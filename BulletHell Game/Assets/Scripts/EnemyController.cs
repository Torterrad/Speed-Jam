using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    GameObject manager;
    
    public int dmg;

    public ParticleSystem passThrough;
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
                ScreenShakeController.instance.StartShake(.2f, .25f);
                manager.GetComponent<ScoreSystem>().score += 10 * manager.GetComponent<ScoreSystem>().multiplier;
                //other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == true)
            {
                ScreenShakeController.instance.StartShake(.2f, .25f);
                manager.GetComponent<ScoreSystem>().score += 10 * manager.GetComponent<ScoreSystem>().multiplier;
                //other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == true)
            {
                ScreenShakeController.instance.StartShake(.2f, .25f);
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
                
                passThrough.Play();
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == true)
            {
                
                passThrough.Play();
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == true)
            {
                
                passThrough.Play();
                other.GetComponent<PlayerController>().gravAmount += other.GetComponent<PlayerController>().gravIncrease;
            }
            passThrough.Play();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (this.tag == "BlueEnemy" && other.GetComponent<PlayerController>().isBlue == true)
        {
            passThrough.Stop();
        }
        if (this.tag == "GreenEnemy" && other.GetComponent<PlayerController>().isGreen == true)
        {
            passThrough.Stop();
        }
        if (this.tag == "RedEnemy" && other.GetComponent<PlayerController>().isRed == true)
        {
            passThrough.Stop();
        }
    }
}
