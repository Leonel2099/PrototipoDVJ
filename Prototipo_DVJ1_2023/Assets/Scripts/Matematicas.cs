using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matematicas : MonoBehaviour
{
    public float degrees; // variable que representa "GRADOS"
    public float radians; // variable que representa "RADIANES"
    public float speedRotation; // variable que representa "VELOCIDAD DE ROTACION"
    public float countRotation; // variable que representa "CONTADOR DE ROTACION"

    public float radiusX;
    public float radiusY;

    public Transform center;

   // public GameObject prefabBullet;

 



    void Update()
    {
        degrees += speedRotation * Time.deltaTime;
        radians = degrees * Mathf.Deg2Rad; // Convertimos a radianes 

        Vector3 posInCircles = Vector3.zero;
        posInCircles.x=Mathf.Cos(radians) * radiusX;
        posInCircles.y= Mathf.Sin(radians)* radiusY;

        this.transform.position = center.position + posInCircles;

      /**  if(Input.GetMouseButton(0))
        {
            GameObject bullet = GameObject.Instantiate(prefabBullet);
            bullet.transform.position=this.transform.position;
            bullet.transform.forward=(this.transform.position - center.position).normalized;

        }if (Input.GetMouseButton(1))
        {
            for (int i = 0; i < 360; i = 360 / 4)
            {
                Vector3 direction = Vector3.zero;
                direction.x = Mathf.Cos((i+degrees) * Mathf.Deg2Rad);
                direction.x = Mathf.Sin((i+degrees) * Mathf.Deg2Rad);

                GameObject bullet = GameObject.Instantiate(prefabBullet);
                bullet.transform.position = this.transform.position+direction;
                bullet.transform.forward = direction;
            }
        }*/
        countRotation = degrees / 360;
    }
}
