using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public AudioClip jumpClip;
    public AudioClip hazardClip;

    public GameManager gm;
    public float speed = 1000;
    public float jumpSpeed = 8;
    public float hazardSpeed = 15;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    private SpriteRenderer sr;
    private Animator anim;

    bool jumping;
    float xMove;

    public float distanceCheckAmount = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (xMove != 0)
        {
            anim.SetBool("Moving", true);
            if (xMove <0)
            {
                sr.flipX = true;
            } else if (xMove > 0)
            {
                sr.flipX = false;
            }
        }
        else
        {
            anim.SetBool("Moving", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            gm.PlaySound(jumpClip);
            if (!jumping)
            {
                anim.SetTrigger("Jumping");
            }

            jumping = true;
        }

        
    }


    
    

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            gm.PlaySound(hazardClip);
            Debug.Log("Triggered");
            Destroy(gameObject);
        }
    }




    public bool GroundCheck()
    {
        bool onGround = Physics2D.Raycast(transform.position, Vector2.down, distanceCheckAmount, ground);

        return onGround;

    }

   
}





