using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class MeteorSpawner: MonoBehaviour
{
    public Vector3 velocity = new Vector3(1, 0, -1);
    public float speed = 1.0f;
    [SerializeField] private float countdown;

    public MeteorInstantiate bullet;
    public Transform BulletPosition;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {

            MeteorInstantiate newBullet = Instantiate(bullet, BulletPosition.position, Quaternion.identity);
            newBullet.velocity = velocity;
            newBullet.speed = speed + 5f;
            countdown= 5f;
        }
    }
}
