using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void Game()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    public void Exit()
    {
        Debug.Log("Salir...");
        Application.Quit(); 
    }

}
