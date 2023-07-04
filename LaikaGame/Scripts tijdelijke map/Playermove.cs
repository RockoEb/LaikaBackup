using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;


    private bool top;
    public float Jumpforce;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


        if(top == false) 
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            }

        }


        Flip();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.gravityScale *= -1;
            Rotation();

        }

        if (top == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log("Jump");
                Debug.Log(gameObject.transform.position);
                rb.AddForce(Vector2.up * Jumpforce);

            }
        }
    }

    private void FixedUpdate()
    {
 
       if(KBcounter <= 0)
       {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
       }
        else
        {
            Debug.Log(KBforce + " " + knockFromRight);
            if(knockFromRight == true) 
            {
                rb.velocity = new Vector2(-KBforce, KBforce);

            }
            if(knockFromRight == false) 
            {
                rb.velocity = new Vector2(KBforce, KBforce);
            }

            KBcounter -= Time.deltaTime;

        }
        
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
