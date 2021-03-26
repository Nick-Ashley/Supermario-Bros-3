using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;
    
    public float bounceForce;
    public AudioSource audioSourceSquish;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        if (bounceForce <= 0)
        {
            bounceForce = 20.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squish")
        {
            if(!pm.isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
                audioSourceSquish.Play();
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);           
            Destroy(gameObject);
            //if lives are greater than 0 respan and continue level
        }
       else if (collision.gameObject.tag == "EnemeyWalker")
        {
            GameManager.instance.lives--;
            Destroy(gameObject);

        }
       else if (collision.gameObject.tag == "Pit")
        {
            GameManager.instance.lives--;
          
            Destroy(gameObject);
        }

       
        
    }

    
}
