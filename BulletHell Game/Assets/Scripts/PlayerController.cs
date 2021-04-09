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

    public TrailRenderer trail;

    public GameObject redTrail;
    public GameObject greenTrail;
    public GameObject blueTrail;


    void Start()
    {
        health = maxHealth;
        rend = GetComponent<Renderer>();

        trail = GetComponent<TrailRenderer>();
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
            trail.startColor = Color.red;
            trail.endColor = Color.red;

            turnTo = Color.red;
            rend.material.color = turnTo;

            redTrail.SetActive(true);
            greenTrail.SetActive(false);
            blueTrail.SetActive(false);
           
        }
        if (colourState == 2)
        {
            isRed = false;
            isBlue = true;
            isGreen = false;
            trail.startColor = Color.blue;
            trail.endColor = Color.blue;
            turnTo = Color.blue;
            rend.material.color = turnTo;

            redTrail.SetActive(false);
            greenTrail.SetActive(false);
            blueTrail.SetActive(true);
        }
        if (colourState == 3)
        {
            isRed = false;
            isBlue = false;
            isGreen = true;
            turnTo = Color.green;
            trail.startColor = Color.green;
            trail.endColor = Color.green;
            rend.material.color = turnTo;
            redTrail.SetActive(false);
            greenTrail.SetActive(true);
            blueTrail.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CloseCall")
        {
            gameManager.GetComponent<ScoreSystem>().multiplier += 1;
        }
    }
}
