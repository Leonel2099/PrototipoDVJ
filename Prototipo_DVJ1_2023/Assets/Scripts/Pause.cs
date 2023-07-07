using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject blur;
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        blur.SetActive(true);
        menuPausa.SetActive(true);
    }
    
    public void Continuar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        blur.SetActive(false);
        menuPausa.SetActive(false);
    }

public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Cerrando Juego");
    }


}
