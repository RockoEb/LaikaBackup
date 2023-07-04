using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOverUI;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
       
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
}
