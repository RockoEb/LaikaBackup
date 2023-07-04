using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroVidManeger : MonoBehaviour

    // zorg ervoor dat beide scenes in de scene map staan
    // ook moeten beide scenes in buildsettings staan (Dit valt onder File, links bovenin)
    // maak een video map aan en sleep de video er in
    // maak in de assets een render texture aan
    // zet de size van de render texture naar 1920 x 1080 (size van intro cutscene)
    // maak in de hiarchy een videomaneger en UI raw image aan
    // zet de raw image naar full screen
    // sleep vanuit de assets de aangemaakte render texture in de texture van de raw image
    // ga nu naar de videomaneger, sleep de orignele mp4 video in de video clip en de render texture in de target texture
    // maak nu een empty game object aan in de hiarchy, sleep daar dit script op
    // zet in levelloaded de volledige naam van het level dat je laden wilt
    // zet in timer de lengte (in seconden) van de video die zich afspeelt, als de timer op is word de aangegeven scene geladen.


{
    public string LevelLoaded;
    public float timer = 82f;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            SceneManager.LoadScene(LevelLoaded);
        }
    }
}
