using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlataform : MonoBehaviour
{
    public bool pressButton = false;
    

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name=="Capsule")
        {
            pressButton = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            pressButton = false;
        }
    }

}

