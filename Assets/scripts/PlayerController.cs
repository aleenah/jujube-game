using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 move;
    bool jump = false;
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
            Destroy(collision.gameObject);
        }
    }
}
