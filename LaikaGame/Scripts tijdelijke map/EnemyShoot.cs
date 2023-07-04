using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform BulletPosition;
    private float Timer;
    private GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);

        if(distance < 100)
        {
            Timer += Time.deltaTime;

            if (Timer > 2)
            {
                Timer = 0;
                shoot();
            }

        }


       
    }

    void shoot()
    {
        Instantiate(Bullet, BulletPosition.position, Quaternion.identity);
    }
}
