using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private float speed = 3f;
    private float detectionRange = 25f;
    private string state;
    public GameObject player;
    double distance;
    private Animator animationEnemy;



    private void Start()
    {
        state = StateMachine.IDLE;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animationEnemy = GetComponent<Animator>();
    }

    private void Update()
    {
            SetBehaviour();
            Display();
    }

    private void Display()
    {
        switch (state)
        {
            case StateMachine.IDLE:
                animationEnemy.SetBool("Idle", true);
                animationEnemy.SetBool("Alert", false);
                animationEnemy.SetBool("Attack", false);
                break;
            case StateMachine.ALERT:
                animationEnemy.SetBool("Idle", false);
                animationEnemy.SetBool("Alert", true);
                animationEnemy.SetBool("Attack", false);
                break;
            case StateMachine.ATTACK:
                animationEnemy.SetBool("Attack", true);
                animationEnemy.SetBool("Idle", false);
                animationEnemy.SetBool("Alert", false);
                
                MoveTowardsPlayer();

                break;
        }
    }



    private double CalculateDistance()
    {
        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.z - transform.position.z, 2));
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
                    else if (distance <= 5f)
                    {
                        state = StateMachine.ALERT;
                    }
                }
                break;
            case StateMachine.ALERT:
                {
                    if (distance > detectionRange)
                    {
                        state = StateMachine.IDLE;
                    }
                    else if (distance <= 4f)
                    {
                        state = StateMachine.ATTACK;
                    }
                    else if (distance >= 8f)
                    {
                        state = StateMachine.IDLE;
                    }
                }
                break;
            case StateMachine.ATTACK:
                {
                    if (distance > detectionRange)
                    {
                        state = StateMachine.IDLE;
                    }
                    else if (distance > 4f && distance < 8f)
                    {
                        state = StateMachine.ALERT;
                    }
                    else if (distance >= 8f)
                    {
                        state = StateMachine.IDLE;
                    }
                }
                break;
        }
    }

    private void MoveTowardsPlayer()
    {
       
        Vector3 direction = new Vector3(playerTransform.position.x, 0, playerTransform.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
        transform.forward = direction;
        direction.Normalize(); 
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}