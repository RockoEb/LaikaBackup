using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private float timeTillSpawn;
    public float startTimeTillSpawn;

    public GameObject lazer;
    public Transform whereToSpawn;

    // Update is called once per frame
    void Update()
    {
        if(timeTillSpawn <= 0)
        {
            Instantiate(lazer, whereToSpawn.position, whereToSpawn.rotation);

            timeTillSpawn = startTimeTillSpawn;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;
        }
    }
}
