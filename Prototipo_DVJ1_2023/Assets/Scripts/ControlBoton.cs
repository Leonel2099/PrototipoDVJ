using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoton : MonoBehaviour
{

    public bool jugadorEncima = false;

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
