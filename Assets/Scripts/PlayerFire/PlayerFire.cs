using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerFire : MonoBehaviour

{

    SpriteRenderer marioSprite;

    public Transform SpawnPointRight;
    public Transform SpawnPointLeft;

    public float projectileSpeed;
    public Projectile projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }
        if (!projectilePrefab)
        {
            Debug.Log("Unity Inspector Values Not Set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            if(CanvisManager.IsGamePaused == false)
            {
                FireProjectile();
            }
        }
    }
    void FireProjectile()
    {
        if (marioSprite.flipX)
        {
            Debug.Log("Fire Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, SpawnPointRight.position, SpawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }
        else
        {
            Debug.Log("Fire Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, SpawnPointLeft.position, SpawnPointLeft.rotation);
            projectileInstance.speed = projectileSpeed * -1;
        }

    }
}
