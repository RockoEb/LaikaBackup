using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController2D controller;
    public ParticleSystem dust;
    public Animator animator;

    private float horizontal;
    private float speed = 18f;
    private float jumpingPower = 16f;
    private float jumpinpowerReverse = -16;
    private bool isFacingRight = true;
    private bool GravityOn = false;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private float jumpBufferCounterGravity;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;


    private bool top;

    //Om gravity aan te zetten, maak 2 empty game objects met triggers
    // Geef 1 de tag TriggerON en de ander TriggerOFF
    //Plaats de TriggerOn op het punt waar je de gravity aan wilt en de TriggerOFF waar je de gravity uit wilt

    public AudioSource jump;
    public AudioSource gravFlip;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        jump = audioSources[0];
        gravFlip = audioSources[1];
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
            animator.SetBool("IsJumping", true);
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            jumpBufferCounterGravity = jumpBufferTime;
        }
        else
        {
            jumpBufferCounterGravity -= Time.deltaTime;
        }

        if (top == false)
        {
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                jumpBufferCounter = 0f;

                CreateDust();
                
            }


            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
                jump.Play();

                coyoteTimeCounter = 0f;
            }
        }

        if (top == true)
        {
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpinpowerReverse);

                jumpBufferCounter = 0f;

                CreateDust();
                
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
                jump.Play();

                coyoteTimeCounter = 0f;
            }
        }


        Flip();


        if (GravityOn == true)
        {
            if (jumpBufferCounterGravity > 0f && coyoteTimeCounter > 0f)
            {
                rb.gravityScale *= -1;
                Rotation();
                gravFlip.Play();

                jumpBufferCounterGravity = 0f;
            }
        }


    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {

        if (KBcounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            Debug.Log(KBforce + " " + knockFromRight);
            if (knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBforce, KBforce);

            }
            if (knockFromRight == false)
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

    public bool IsGrounded()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TriggerON")
        {
            Debug.Log("Trigger");
            GravityOn = true;
        }

        if (other.gameObject.tag == "TriggerOFF")
        {
            Debug.Log("OFF");
            GravityOn = false;
        }


    }
    void CreateDust()
    {
        dust.Play();
    }
}
