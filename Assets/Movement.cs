using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance = null;
    public float _movementSpeed = 10;
    public bool isJumping = false;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        Vector3 movement = new();
        movement.x += Input.GetAxisRaw("Horizontal")*10;
        GetComponent<Rigidbody2D>().AddForce(movement * Time.deltaTime * 100);
        if (Input.GetAxis("Vertical") is float jump && jump >= 0.1f && !isJumping)
        {
            isJumping = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump * 100 * Time.deltaTime*1500));
            Timing.CallDelayed(0.5f, () => { isJumping = false; });
        }
    }

    private void FixedUpdate()
    {

    }
}
