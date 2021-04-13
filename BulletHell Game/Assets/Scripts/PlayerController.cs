using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    //public Camera cam;

    Vector2 mouseAim;

    float horizontal;
    float vertical;

    private float health;
    public float maxHealth;

    public float speed = 2f;
    public float startSpeed;
    public float duration = .5f;

    public Rigidbody2D rb;

    private int colourState = 1;

    public bool isRed = false;
    public bool isBlue = false;
    public bool isGreen = false;

    private Renderer rend;

    public Color turnTo = Color.white;

    public GameObject gameManager;

    public TrailRenderer trail;

    public GameObject redTrail;
    public GameObject greenTrail;
    public GameObject blueTrail;


    public ParticleSystem redDeath;
    public ParticleSystem greenDeath;
    public ParticleSystem blueDeath;

    public SpriteRenderer sRenderer;
    public float countDown = 1f;
    public float minimumCountDown = 0f;

    public Animator nearMissText;
    public Animator multiplierText;
    public Animation anim;

    //Variables for player squash and stretch.
    public float scaleStart = 0.05f;
    public float scaleOldX;
    public float scaleOldY;
    public float scaleNewX;
    public float scaleNewY;
    public float scaleRate = 0.0005f;
    public float scaleMin = 0.04f;
    public float scaleMax = 0.06f;

    //Variables for dash.
    private bool isDashing;
    private bool canMove = true;
    public float dashTime = 0.2f;
    public float dashSpeed = 8f;
    public float dashCooldown = 1f;
    private float dashTimeLeft;
    private float lastDash = -100f;

    public bool dead = false;

    public float gravAmount;
    public float maxGravAmount;
    public float gravIncrease;

    public ProgressBar gravSlider;

    public GameObject redRight;
    public GameObject redLeft;
    public GameObject greenRight;
    public GameObject greenLeft;
    public GameObject blueRight;
    public GameObject blueLeft;

    private float timer;
    public float maxTimer;




    void Start()
    {
        health = maxHealth;
        //rend = GetComponent<Renderer>();
        rend = sRenderer;
        scaleOldX = scaleStart;
        scaleOldY = scaleStart;
        scaleNewX = scaleStart;
        scaleNewY = scaleStart;

        trail = GetComponent<TrailRenderer>();


        gravAmount = maxGravAmount;
        gravSlider.setMaxGravAmount(maxGravAmount);

        startSpeed = speed;
        timer = maxTimer;
    }


    void Update()
    {
        timer += Time.deltaTime;
       


        if (timer >= 2)
        {
            gravAmount += 0.05f;
            timer = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) && gravAmount > 0)
        {
            gameManager.GetComponent<TimeManager>().SlowMo();
            gravAmount -= 2 * Time.deltaTime;
        }
        if (gravAmount < maxGravAmount)
        {
            gravSlider.SetGravAmount(gravAmount);
        }
        if (gravAmount <= 0)
        {
            gravAmount = 0;
        }

        if (gravAmount >= maxGravAmount)
        {
            gravAmount = maxGravAmount;
        }
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        SquashAndStretch();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("1. Space pressed");
            if (Time.time >= (lastDash + dashCooldown))
            {
                Debug.Log("2. Time.time >= (lastDash + dashCooldown)");
                AttemptToDash();
            }
        }

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

            greenRight.SetActive(true);
            blueLeft.SetActive(true);
            redLeft.SetActive(false);
            redRight.SetActive(false);
            greenLeft.SetActive(false);
            blueRight.SetActive(false);

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

            greenRight.SetActive(false);
            blueLeft.SetActive(false);
            redLeft.SetActive(false);
            redRight.SetActive(true);
            greenLeft.SetActive(true);
            blueRight.SetActive(false);

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

            greenRight.SetActive(false);
            blueLeft.SetActive(false);
            redLeft.SetActive(true);
            redRight.SetActive(false);
            greenLeft.SetActive(false);
            blueRight.SetActive(true);

            redTrail.SetActive(false);
            greenTrail.SetActive(true);
            blueTrail.SetActive(false);
        }
        if (health <= 0)
        {

            if (isRed)
            {
                countDown -= Time.deltaTime;
                if (countDown >= minimumCountDown)
                {
                    Destroy(redTrail);
                    GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(die());
                }
                if (countDown <= minimumCountDown)
                {
                    redDeath.Stop();
                }


            }
            if (isGreen)
            {

                countDown -= Time.deltaTime;
                if (countDown >= minimumCountDown)
                {
                    Destroy(greenTrail);
                    GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(die());
                }
                if (countDown <= minimumCountDown)
                {
                    greenDeath.Stop();
                }
            }
            if (isBlue)
            {
                countDown -= Time.deltaTime;
                if (countDown >= minimumCountDown)
                {
                    Destroy(blueTrail);
                    GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(die());
                }
                if (countDown <= minimumCountDown)
                {
                    blueDeath.Stop();
                }

            }
            //gameObject.SetActive(false);
        }

        CheckDash();
    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        //Vector2 lookDirection = mouseAim - rb.position;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        // float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        // rb.rotation = angle;
    }

    private void AttemptToDash()
    {
        if (lastDash + dashCooldown < Time.time)
        {
            Debug.Log("3. lastDash + dashCooldown < Time.time");
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;
        }
    }

    private void CheckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                //rb.AddForce(rb.velocity * dashSpeed);
                speed = dashSpeed;
                dashTimeLeft -= Time.deltaTime;
            }
            else
            {
                speed = startSpeed;
                isDashing = false;
                canMove = true;
            }
        }
    }

    public void SquashAndStretch()
    {
        if (horizontal != 0)
        {
            RescalePlayer(ref scaleNewX, scaleMax, ref scaleNewY, scaleMin, ref scaleOldX, ref scaleOldY);
        }
        else
        {
            RescalePlayer(ref scaleNewY, scaleStart, ref scaleNewX, scaleStart, ref scaleOldY, ref scaleOldX);
        }

        if (vertical != 0)
        {
            if (scaleNewY <= scaleMax && scaleNewX >= scaleMin)
            {
                scaleNewX = scaleOldX - scaleRate;
                scaleNewY = scaleOldY + scaleRate;
                transform.localScale = new Vector3(scaleNewX, scaleNewY, 1f);
            }
        }
        else
        {
            if (scaleNewX <= scaleStart && scaleNewY >= scaleStart)
            {
                scaleNewX = scaleOldX + scaleRate;
                scaleNewY = scaleOldY - scaleRate;
                transform.localScale = new Vector3(scaleNewX, scaleNewY, 1f);
            }
        }
        scaleOldX = scaleNewX;
        scaleOldY = scaleNewY;
    }

    public void RescalePlayer(ref float scaleNewA, float scaleCapA, ref float scaleNewB, float scaleCapB, ref float scaleOldA, ref float scaleOldB)
    {
        if (scaleNewA <= scaleCapA && scaleNewB >= scaleCapB)
        {
            scaleNewA = scaleOldA + scaleRate;
            scaleNewB = scaleOldB - scaleRate;
            transform.localScale = new Vector3(scaleNewA, scaleNewB, 1f);
        }
        scaleOldA = scaleNewA;
        scaleOldB = scaleNewB;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        ScreenShakeController.instance.StartShake(.3f, 1f);
        gameManager.GetComponent<TimeManager>().SlowMo();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CloseCall")
        {
            gameManager.GetComponent<ScoreSystem>().multiplier += 1;
            nearMissText.SetTrigger("NearMissTrigger");
            multiplierText.SetTrigger("MultiplierTextPopTrigger");
            gameManager.GetComponent<ScoreSystem>().multiplierTime = gameManager.GetComponent<ScoreSystem>().maxMultiplierTime;
        }
        if (other.tag == "RedCloseCall" && this.isRed == false)
        {
            gameManager.GetComponent<ScoreSystem>().multiplier += 1;
            nearMissText.SetTrigger("NearMissTrigger");
            multiplierText.SetTrigger("MultiplierTextPopTrigger");
            gameManager.GetComponent<ScoreSystem>().multiplierTime = gameManager.GetComponent<ScoreSystem>().maxMultiplierTime;
        }
        if (other.tag == "GreenCloseCall" && this.isGreen == false)
        {
            gameManager.GetComponent<ScoreSystem>().multiplier += 1;
            nearMissText.SetTrigger("NearMissTrigger");
            multiplierText.SetTrigger("MultiplierTextPopTrigger");
            gameManager.GetComponent<ScoreSystem>().multiplierTime = gameManager.GetComponent<ScoreSystem>().maxMultiplierTime;
        }
        if (other.tag == "BlueCloseCall" && this.isBlue == false)
        {
            gameManager.GetComponent<ScoreSystem>().multiplier += 1;
            nearMissText.SetTrigger("NearMissTrigger");
            multiplierText.SetTrigger("MultiplierTextPopTrigger");
            gameManager.GetComponent<ScoreSystem>().multiplierTime = gameManager.GetComponent<ScoreSystem>().maxMultiplierTime;
        }


    }

    IEnumerator die()
    {
        if (isRed)
        {
            Destroy(redTrail);
            redDeath.Play();

        }
        if (isGreen)
        {
            Destroy(greenTrail);
            greenDeath.Play();

        }
        if (isBlue)
        {
            Destroy(blueTrail);
            blueDeath.Play();

        }
        yield return new WaitForSeconds(duration);

        greenDeath.Stop();
        blueDeath.Stop();
        redDeath.Stop();
        gameManager.GetComponent<SpawnEntity>().playerDead = true;
        Destroy(gameObject);

    }
}
