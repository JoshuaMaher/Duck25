using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class teleportBase : MonoBehaviour
{
    public GameObject destination;
    public bool cooldown = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !cooldown)
        {
            other.transform.position = destination.transform.position;
            destination.GetComponent<teleportBase>().cooldown = true;
            Timing.CallDelayed(1f, () => { destination.GetComponent<teleportBase>().cooldown = false; });
        }
    }
}
