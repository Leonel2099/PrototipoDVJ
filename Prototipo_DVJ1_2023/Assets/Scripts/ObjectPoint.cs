using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    /*Variables*/
    public GameObject objectExp;
    public float valoreObject;
    public int speedObject = 50;

    private void Update()
    {
        transform.Rotate(Vector3.up*speedObject*Time.deltaTime);//Rotan en su ejeY
    }
    /*Cuando los jugadores chocan con los objetos se destruyen y suman puntajes*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectExp.GetComponent<PointExp>().pointExp += valoreObject;
            Destroy(gameObject);
        }
    }
}
