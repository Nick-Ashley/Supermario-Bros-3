using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collision2D))]
public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);


    }
    void OnEnable()
    {
        GameObject[] pickUpObjects = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject Pickup in pickUpObjects)
        {
            Physics2D.IgnoreCollision(Pickup.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)

    {
       
        if (gameObject.tag == "MarioProjectile")
        {


            if (collision.gameObject.tag == "EnemyWalker" || collision.gameObject.tag == "Squish")
            {
                
                collision.gameObject.GetComponent<EnemyWalker>().IsDead();
                
                Destroy(gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
                Destroy(gameObject);
        }
        if(gameObject.tag == "EnemyProjectile") 
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
                Destroy(gameObject);
        }
    }

}
