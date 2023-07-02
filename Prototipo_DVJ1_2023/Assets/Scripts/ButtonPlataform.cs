using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlataform : MonoBehaviour
{
    public bool pressButton = false;
    

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

