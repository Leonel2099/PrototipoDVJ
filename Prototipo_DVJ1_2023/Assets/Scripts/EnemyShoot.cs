using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public Transform shootPosition;
    public GameObject bulletPrefabs;
    public float bulletSpeed;

    void Start()
    {

        InvokeRepeating("Shoot", 5f, 5f);
    }

    void Update()
    {        
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs, shootPosition.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = (player.transform.position - transform.position).normalized * bulletSpeed;
    }
}
