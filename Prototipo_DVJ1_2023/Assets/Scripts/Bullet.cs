using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        GameObject.Destroy(this.gameObject,2);
    }

    private void Update()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }
}
