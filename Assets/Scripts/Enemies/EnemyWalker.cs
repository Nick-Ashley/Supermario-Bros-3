using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyWalker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public int health;
    public float speed;
    public AudioSource audioSourceSquish;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0) 
        {
            speed = 5.0f;
        }
        if (health <= 0) 
        {
            health = 3;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Death") && !anim.GetBool("Squish"))
        if (sr.flipX) 
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MarioProjectile")
        {
            health--;
            Debug.Log("firhit");
            if (health < 0)
            {
                GameManager.instance.score++;
                Destroy(gameObject);
            }
        }
    }

    public void IsDead()
    {
        health--;
        if(health<=0)
        {
            anim.SetBool("Death", true);
            rb.velocity = Vector2.zero;
        }


    }
    public void IsSquished()
    {
        anim.SetBool("Squish", true);
        rb.velocity = Vector2.zero;
    }
    public void FinishedDeath()
    {
        GameManager.instance.score++;
        audioSourceSquish.Play();
        Destroy(gameObject);

    }
}
