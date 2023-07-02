using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    public GameObject objectExp;
    public float valoreObject;
    public int speedObject = 50;

    private void Update()
    {
        transform.Rotate(Vector3.up*speedObject*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectExp.GetComponent<PointExp>().pointExp += valoreObject;
            Destroy(gameObject);
        }
    }
}
