using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyTurrent : MonoBehaviour
{
    public Transform projectileSpawnPointLeft;
    public Transform projectileSpawnPointRight;
    public Projectile projectilePrefab;

    SpriteRenderer enemyTurrent;
    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;
    public GameObject player;
    public GameObject turrent;

    public float distance;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemyTurrent = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }
        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, turrent.gameObject.transform.position) < distance)
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetBool("Fire", true);
                timeSinceLastFire = Time.time;
            }
        }
        else
        {
            Debug.Log("not detected");
        };

        if (enemyTurrent.flipX && player.gameObject.transform.position.x < turrent.gameObject.transform.position.x || !enemyTurrent.flipX && player.gameObject.transform.position.x > turrent.gameObject.transform.position.x)
        {
            enemyTurrent.flipX = !enemyTurrent.flipX;
        }
    }
    public void Fire()
    {
        if (!enemyTurrent.flipX)
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            temp.speed = projectileForce *-1;
        }
        else
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            temp.speed = projectileForce ;
        }
    }
    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
