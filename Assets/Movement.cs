using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MEC;

public class Movement : MonoBehaviour
{
    public float speed = 8;
    private float move;

    public Rigidbody2D rb;

    public bool facingRight = true;
    public bool isJumping = false;

    public int jumpForce;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
   
            move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(speed * move, rb.velocity.y);
      

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }

    void Jump()
    {
       if (!isJumping)
       {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;

        }
  
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }
    }

    

}

