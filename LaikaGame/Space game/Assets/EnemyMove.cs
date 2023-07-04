using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    //script voor het bewegen van A naar B van de enemy en als de speler dicht bij komt dat de enemy de speler achterna gaat.
    // om dit script te laten werken heb je patrol points nodig in je unity.


    //patrol variabele
    public Transform[] patrolpoints;
    public float moveSpeed;
    public int patrolDestination;

    //chase variabele 
    public Transform playertransform;
    public bool isChasing;
    public float chaseDistance;


    // Update is called once per frame
    void Update()
    {

        if (isChasing)
        {

            if(transform.position.x > playertransform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playertransform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);

                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playertransform.position) < chaseDistance)
            {
                isChasing = true;
            }


            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    patrolDestination = 0;
                }
            }
        }


    }
}
