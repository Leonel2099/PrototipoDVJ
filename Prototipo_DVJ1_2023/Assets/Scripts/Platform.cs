using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    /*Variables*/
    public GameObject[] waypoints;  // puntos de ruta
    public float platformSpeed = 2; // velocidad de la plataforma
    private int waypointsIndex = 0; // es de donde va a comenzar
    
    private void FixedUpdate()
    {
        movePlataform();
    }
    /*Desplaza la plataforma por los puntos establecidos dentro del array*/
    void movePlataform()
    {
        /*Compara la distancia de la plataforma asi pasa al siguiente punto*/
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1)
        {
            waypointsIndex++;
            if (waypointsIndex >= waypoints.Length) //vuelve al punto 0 en forma de loop
            {
                waypointsIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed * Time.deltaTime);
    }
    /*Corrobora si unos de los player entra en colision con plataformas*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
            other.gameObject.transform.SetParent(transform);//Mantienen la misma posicion
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Max" || other.gameObject.name == "Rocky")
        {
            other.gameObject.transform.SetParent(null);

        }
    }
}

