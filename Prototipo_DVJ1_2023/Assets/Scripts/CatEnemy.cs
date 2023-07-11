using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemy : MonoBehaviour
{
    public Transform playerTransform;
    public Transform shootPosition;
    public GameObject bulletPrefabs;
    public float bulletSpeed;
    private string state;
    double distance;
    public float detectionRange;
    private float firerate = 0.5f;
    private float timer;

    void Start()
    {
        state = StateMachine.IDLE;
    
    }


    void FixedUpdate()
    {
        DisplayCat();
        SetBehaviour();          
    }

    private void DisplayCat()
    {
        switch (state)
        {
            case StateMachine.IDLE:
                 break;
            case StateMachine.ATTACK:
                timer += Time.deltaTime;
                if(timer >= firerate)
                {
                    AttackPlayer();
                    timer = 0f;
                }

                break;
        }
    }

    private void AttackPlayer()
    {       
        GameObject bullet = Instantiate(bulletPrefabs, shootPosition.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = (playerTransform.transform.position - shootPosition.position).normalized * bulletSpeed;
    }

    private double CalculateDistance()
    {
        distance = Mathf.Sqrt(Mathf.Pow(playerTransform.position.x - transform.position.x, 2) + Mathf.Pow(playerTransform.position.z - transform.position.z, 2));
        return distance;
    }


    private void SetBehaviour()
    {
        distance = CalculateDistance();
        

        switch (state)
        {
            case StateMachine.IDLE:
                {
                    if (distance > detectionRange)
                    {
                        state = StateMachine.IDLE;
                    }
                    else if (distance <= 10f)
                    {
                        state = StateMachine.ATTACK;
                    }
                }
                break;
   
            case StateMachine.ATTACK:
                {
                    if (distance > detectionRange)
                    {
                        state = StateMachine.IDLE;
                   
                    }

                }
                break;
        }
    }

}
