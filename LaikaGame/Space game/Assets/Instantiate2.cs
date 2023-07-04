using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate2 : MonoBehaviour
{
    public Vector3 velocity = new Vector3(1, 0, -1);
    public float speed = 5.0f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;

    }
}
