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
    public Color alert, idle, attack;
    private void Start()
    {
        state = StateMachine.IDLE;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", idle);
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
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", idle);
                // En caso de que el enemigo tenga una animación de reposo
                break;
            case StateMachine.ALERT:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", alert);
                // RotateTowardsPlayer();
                break;
            case StateMachine.ATTACK:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", attack);
                //RotateTowardsPlayer();
                MoveTowardsPlayer();

                break;
        }
    }

    //private void RotateTowardsPlayer()
    //{
    //    Vector3 direction = playerTransform.position - transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    transform.rotation = lookRotation;
    //}

    private double CalculateDistance()
    {
       distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2)+ Mathf.Pow(player.transform.position.z - transform.position.z, 2));
        return distance;
       // return Vector3.Distance(playerTransform.position, transform.position);
    }

    private void SetBehaviour()
    {
        distance = CalculateDistance();
        Debug.Log(distance);
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
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}