using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 move;

    bool jump = false;
    int score = 0;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public float timeLeft = 60;

    Vector3 startPOS;

    public LayerMask ground;

    AudioSource src;
    public AudioClip pointSound;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPOS = transform.position;
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -9)
        {
            transform.position = startPOS;
        }

       timeLeft -= Time.deltaTime;
       if (timeLeft <= 0)
       {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
       }
       timeText.text = "Time: " + timeLeft.ToString("0.0");
       
       var feet = new Vector2(transform.position.x, transform.position.y - 0.7f);
       var dimensions = new Vector2(0.8f, 0.1f);
       var grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);

       move.x = Input.GetAxis("Horizontal");

       if (Input.GetButtonDown("Jump") && grounded) 
       {
        jump = true;
        src.PlayOneShot(jumpSound);
       }

    }

    void FixedUpdate()
    {
        rb.AddForce(move * 8);

        if (jump) 
        {
            jump = false;
            rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("olive"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
            src.PlayOneShot(pointSound);
        }
    }
}
