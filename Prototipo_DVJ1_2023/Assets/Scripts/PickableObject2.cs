using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject2 : MonoBehaviour
{
    /*Vraiables*/
    public bool isPickable = true;

    /*Detecta si hay colision con un tag especifico*/
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObjects2>().ObjectToPickUp2 = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObjects2>().ObjectToPickUp2 = null;
        }
    }
}

