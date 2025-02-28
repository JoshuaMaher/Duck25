using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireballSpeed;
    public Transform firePoint;
    public GameObject fireball;
    public float shootingTimer;

    public bool isShooting;

    public Movement script;


    void Start()
    {
        isShooting = false;
    }


    void Update()
    {
        if (Input.GetButtonDown("Shoot") && !isShooting) //shooting
        {
            StartCoroutine(ShootFireball());
        }
    }


    IEnumerator ShootFireball()
    {
        int direction() //Returns a value depending on which direction play is facing, multiplies x value of fireball by that value 
        {
            if (script.facingRight == false)
            {
                return -1;
            }
            if (script.facingRight == true)
            {
                return +1;
            }
            else
            {
                return +1;
            }
        }

        int flip180() //Returns value of 180 or 0, depending on what way player is facing, flips fireball on y axis
        {
            if (script.facingRight == false)
            {
                return +180;
            }
            else
            {
                return 0;
            }
        }

        isShooting = true;
        GameObject newFireball = Instantiate(fireball, firePoint.position, Quaternion.Euler(0, 0, 0)); //Spawn in bullet, rotated 270 degrees on z axis 
        newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(fireballSpeed * direction() * Time.fixedDeltaTime, 0f);
        newFireball.transform.localScale = new Vector2(newFireball.transform.localScale.x * direction(), newFireball.transform.localScale.y);
        yield return new WaitForSeconds(shootingTimer);
        isShooting = false;
    }

}
