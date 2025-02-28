using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    
    public float bulletLifetime;
    public GameObject portal;

    private GameObject portal1 = null;
    private GameObject portal2 = null;
    
    void Start()
    {
        StartCoroutine(bulletDie());
    }

    IEnumerator bulletDie()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Explode();
    }



    void Explode()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (portal1 == null)
            {
                portal1 = Instantiate(portal, transform.position, new Quaternion());
                Destroy(this);
                return;
            }

            if (portal2 == null)
            {
                portal2 = Instantiate(portal, transform.position, Quaternion.Euler(Vector3.zero));
                Destroy(this);
                return;
            }
        }
    }
}
