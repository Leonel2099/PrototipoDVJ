using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasando : MonoBehaviour
{
    public Animator bridgeRed;
    public Animator bridgeBlue;
    public Animator bridgeYellow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
            bridgeRed.Play("Red_On");
            bridgeBlue.Play("Blue_On");
            bridgeYellow.Play("Yellow_On");
            

        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
           bridgeRed.Play("Red_Off");
           bridgeBlue.Play("Blue_Off");
           bridgeYellow.Play("Yellow_Off");

        }
            
    }
}
