using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurn : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject enemy;
    public float speed;


    public bool right;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.localScale = new Vector2(1, 1);
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);

        }
        if (left)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Turn"))
        {
            if (right == true)
            {
                right = false;
                left = true;
            }
            else if (left == true)
            {
                right = true;
                left = false;
            }
        }
    }
}
