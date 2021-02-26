using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer MarioSprite;
    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isFire;
    private Vector3 initialScale;
    public bool isCrouch;


    int _score = 0;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Current Score Is " + _score);
        }
    }
    public int maxlives = 3;
    int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives > maxlives)
            {
                _lives = maxlives;
            }
            else if (_lives < 0)
            {
                //run game over code here
            }
            Debug.Log("Current Lives Is" + _lives);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MarioSprite = GetComponent<SpriteRenderer>();

        initialScale = transform.localScale;

        if (speed <= 0)
        {
            speed = 5.0f;
        }
        if (jumpForce <= 0)
        {
            jumpForce = 100;

        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }
        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please set a transfor value for groundcheck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            isFire = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isFire = false;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isCrouch = true;

        }
        else 
        {
            isCrouch = false;
        };

        /*
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouch = false;

        }
        */

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFire", isFire);
        anim.SetBool("isCrouch", isCrouch);


        if (MarioSprite.flipX && horizontalInput < 0 || !MarioSprite.flipX && horizontalInput > 0)
            MarioSprite.flipX = !MarioSprite.flipX;

        
    }

   
    

    public void StartJumpForceChange()
    {
        StartCoroutine(JumpForceChange());

    }
    IEnumerator JumpForceChange()
    {
        jumpForce = 250;

        yield return new WaitForSeconds(8.0f);

        jumpForce = 190;

    }
    
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            if (Input.GetKey(KeyCode.E))
            {
               

                Pickups curPickup = collision.GetComponent<Pickups>();
                switch (curPickup.currentCollectible)
                {

                    case Pickups.CollectibleType.QCOIN:
                        //Add ComponentMenu to Inventory r Other Mechanic
                        Destroy(collision.gameObject);
                        break;
                }
            }
        }

    }





    
    
    
}

