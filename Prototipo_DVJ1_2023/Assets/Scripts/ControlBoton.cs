using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoton : MonoBehaviour
{

    public bool jugadorEncima = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            jugadorEncima = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            jugadorEncima = false;
        }
    }
}
