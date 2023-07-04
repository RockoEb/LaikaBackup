using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{
    // reguleert de health van de speler en Spawning


    //health
    public int maxHealth = 10;
    public int health;

    //spawn
    private Vector3 SpawnIn;
    

    //Healthbar
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite Skull;



    void Start()
    {
        health= maxHealth;
        
    }

    private void Update()
    {
        foreach(Image img in hearts) 
        {
            img.sprite = Skull;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = FullHeart;
        }
        
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            SpawnIn = transform.position;
            Debug.Log("Check");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Thread.Sleep(1000);
        transform.position = SpawnIn;
        if(health <= 0)
        {
            Thread.Sleep(1000);
            SceneManager.LoadScene("Scene1");

            
        }
    }
}
