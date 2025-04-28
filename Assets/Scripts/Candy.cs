using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public GameObject candyVFX;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            UiManager.instance.AddStar();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Instantiate(candyVFX, transform.position, Quaternion.identity);
            //TODO: game over
            Destroy(gameObject);
            
        }
    }
}
