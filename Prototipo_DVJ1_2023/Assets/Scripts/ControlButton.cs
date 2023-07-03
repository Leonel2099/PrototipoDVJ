using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    /*Variable*/
    public bool jugadorEncima = false;

    /*Colision de los jugadores con un boton para reproducir las animaciones de la puerta*/
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
            jugadorEncima = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
            jugadorEncima = false;
        }
    }
}
