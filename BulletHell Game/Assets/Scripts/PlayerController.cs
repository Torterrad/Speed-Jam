using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera cam;

    Vector2 mouseAim;

    float horizontal;
    float vertical;

    private float health;
    public float maxHealth;

    public float speed = 2f;

    public Rigidbody2D rb;

    private int colourState = 1;

    public bool isRed = false;
    public bool isBlue= false;
    public bool isGreen = false;

    private Renderer rend;

    public Color turnTo = Color.white;

    public GameObject gameManager;
    void Start()
    {
        health = maxHealth;
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        mouseAim = cam.ScreenToWorldPoint(Input.mousePosition);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            colourState++;
        }
        if (Input.GetMouseButtonDown(1))
        {
            colourState--;
        }

        if (colourState <= 0)
        {
            colourState = 3;
        }
        if (colourState >= 4)
        {
            colourState = 1;
        }
        if (colourState == 1)
        {
            isRed = true;
            isBlue = false;
            isGreen = false;
            turnTo = Color.red;
            rend.material.color = turnTo;
        }
        if (colourState == 2)
        {
            isRed = false;
            isBlue = true;
            isGreen = false;
            turnTo = Color.blue;
            rend.material.color = turnTo;
        }
        if (colourState == 3)
        {
            isRed = false;
            isBlue = false;
            isGreen = true;
            turnTo = Color.green;
            rend.material.color = turnTo;
        }
        if(health<= 0)
        {
            gameManager.GetComponent<SpawnEntity>().playerDead = true;
            Destroy(gameObject);
        }


    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        Vector2 lookDirection = mouseAim - rb.position;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
