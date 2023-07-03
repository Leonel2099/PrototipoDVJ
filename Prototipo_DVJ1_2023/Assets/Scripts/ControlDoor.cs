using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    /*Variables*/
    public Transform puerta;
    public ControlButton controlButton;
    public float alturaPuertaCerrada = 2.4594f;
    public float alturaPuertaAbierta = -1.72f;
    public float velocidadApertura = 1.0f;

    private bool puertaAbierta = false;
    private float alturaObjetivo;
    private Collider puertaCollider;

    void Start()
    {
        puertaCollider = puerta.GetComponent<Collider>();
        alturaObjetivo = alturaPuertaCerrada;
    }
    void Update()
    { 
        /*Verifica si un jugador esta encima del boton*/
        if (controlButton.jugadorEncima)
        {
            alturaObjetivo = alturaPuertaAbierta;
        }
        else
        {
            alturaObjetivo = alturaPuertaCerrada;
        }

        float nuevaAltura = Mathf.MoveTowards(puerta.localPosition.y, alturaObjetivo, velocidadApertura * Time.deltaTime);//Mueve la posicion de la puerta hacia la altura objetivo
        puerta.localPosition = new Vector3(puerta.localPosition.x, nuevaAltura, puerta.localPosition.z);
        
        /*Comprueba que la puerta alcance la altura objetivo*/
        if (Mathf.Approximately(nuevaAltura, alturaObjetivo))
        {
            puertaAbierta = controlButton.jugadorEncima;
        }
    }
}