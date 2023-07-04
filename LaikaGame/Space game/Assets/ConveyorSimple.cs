using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
    public bool clockwise;
    public float speed;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (clockwise) 
        {
            rb.position += Vector2.left * speed * Time.fixedDeltaTime;
            if (transform.localScale.x == -1) transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rb.position += Vector2.right * speed * Time.fixedDeltaTime;
            if (transform.localScale.x == 1) transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        rb.MovePosition(position);
    }
}

