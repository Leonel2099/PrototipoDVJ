using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlataformMove : MonoBehaviour
{
    public ButtonPlataform plataformScript;
    // la plataforma se movera de un punto a otro indicado por nosotros por l ocual necesito un array
    public GameObject[] waypoints;  // puntos de ruta
    public float platformSpeed = 2; // velocidad de la plataforma
    private int waypointsIndex = 0; // es de donde va a comenzar

    private void Update()
    {
        if (plataformScript.pressButton)
        {
                if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1) // compra la distancia de la plataforma asi pasa al siguiente punto
                {
                    waypointsIndex++;
                    if (waypointsIndex >= waypoints.Length) //vuelve al punto 0 en forma de loop
                    {
                        waypointsIndex = 0;
                    }
                }

                transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed * Time.deltaTime);
        }
       

    }
}