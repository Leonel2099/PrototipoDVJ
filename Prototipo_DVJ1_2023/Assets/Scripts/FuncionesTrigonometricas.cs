using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesTrigonometricas : MonoBehaviour
{
    public float degrees; // variable que representa "GRADOS"
    public float radians; // variable que representa "RADIANES"
    public float speedRotation; // variable que representa "VELOCIDAD DE ROTACION"
    public float countRotation; // variable que representa "CONTADOR DE ROTACION"

    public float radiusX;
    public float radiusY;

    public Transform center;
    void FixedUpdate()
    {
        degrees += speedRotation * Time.deltaTime;
        radians = degrees * Mathf.Deg2Rad; // Convertimos a radianes 

        Vector3 posInCircles = Vector3.zero;
        posInCircles.x=Mathf.Cos(radians) * radiusX;
        posInCircles.y= Mathf.Sin(radians)* radiusY;

        this.transform.position = center.position + posInCircles;
        countRotation = degrees / 360;
    }
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
