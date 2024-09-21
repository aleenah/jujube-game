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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       move.x = Input.GetAxis("Horizontal");

       if (Input.GetButtonDown("Jump")) 
       {
        jump = true;
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
        }
    }
}
