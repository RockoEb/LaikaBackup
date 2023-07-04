using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // dit script zorgt ervoor de de speler damage krijgt als deze tegen de enemy aanloopt.
    // Zet achter de GameObject.Find de naam van de playern in de hiarchy
    // geef een damage int mee aan de enemy sprite
    // set KBtotaltime to anything above 0

    public int damage;
    public PlayerHealth playerhealth;
    public Playermove playermovement;

    private void Start()
    {
        playerhealth = GameObject.Find("Ellie").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            playermovement.KBcounter = playermovement.KBtotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playermovement.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playermovement.knockFromRight = false;
            }
            playerhealth.TakeDamage(damage);
        }
    }
}
