using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private ParticleSystem particle;
    public AudioSource audioSourceBox;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }





    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<PlayerMovement>() && other.contacts[0].normal.y > 0.5f) 
        {
            StartCoroutine(Break());
       
        }

    }

    private IEnumerator Break()
    {
        particle.Play();
        audioSourceBox.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax); 
        Destroy(gameObject);
    }
}
