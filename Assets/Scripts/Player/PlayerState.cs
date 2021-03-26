using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerState : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer MarioSprite;
    public bool isSmall;
    public bool isMario;
    public bool isFire;
    public bool isSquirrl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MarioSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


        anim.SetBool("isSmall", isSmall);
        anim.SetBool("isMario", isMario);
        anim.SetBool("isFire", isFire);
        anim.SetBool("isSquirrl", isSquirrl);
    }
}
