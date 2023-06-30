using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuerta : MonoBehaviour
{
    public Transform puerta;
    public ControlBoton controlBoton;
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
        if (controlBoton.jugadorEncima)
        {
            alturaObjetivo = alturaPuertaAbierta;
        }
        else
        {
            alturaObjetivo = alturaPuertaCerrada;
        }

        float nuevaAltura = Mathf.MoveTowards(puerta.localPosition.y, alturaObjetivo, velocidadApertura * Time.deltaTime);
        puerta.localPosition = new Vector3(puerta.localPosition.x, nuevaAltura, puerta.localPosition.z);

        if (Mathf.Approximately(nuevaAltura, alturaObjetivo))
        {
            puertaAbierta = controlBoton.jugadorEncima;
        }
    }
}