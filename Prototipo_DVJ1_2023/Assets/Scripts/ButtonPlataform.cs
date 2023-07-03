using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlataform : MonoBehaviour
{
    /*Variable*/
    public bool pressButton = false;

    /*Colision de los jugadores con un boton para reproducir las animaciones de la plataforma*/
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name=="Rocky" || other.gameObject.name == "Max")
        {
            pressButton = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Rocky" || other.gameObject.name == "Max")
        {
            pressButton = false;
        }
    }

}

