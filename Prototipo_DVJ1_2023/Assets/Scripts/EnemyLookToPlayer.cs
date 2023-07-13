using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookToPlayer : MonoBehaviour
{
    public Transform player;


    void Update()
    {
        Vector3 enemyToObjectVector = new Vector3(player.position.x, 0, player.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
        transform.forward = enemyToObjectVector;        
    }
}
