using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    
    public float bulletLifetime;


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
}
