using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    
    public int dmg;
    void Start()
    {
        player = GameObject.Find("Player");
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
        }
    }
}
