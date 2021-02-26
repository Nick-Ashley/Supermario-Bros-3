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

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag != "Mario")
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }


    }

}
