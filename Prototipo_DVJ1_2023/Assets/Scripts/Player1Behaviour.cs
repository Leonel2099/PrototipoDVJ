using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Behaviour : MonoBehaviour
{
    /*Variables*/
    private MovementPlayer1 inputPlayer;
    public CharacterController player;
    private Vector2 movementInput;

    public float threshold;
    public Transform mainVecPos;

    private Animator anim;
    private Vector3 playerInput;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
        

    private void Start()
    {
        inputPlayer = new MovementPlayer1();
        inputPlayer.Player1.Enable();
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        StartCoroutine(ReSpawn());
        player.enabled = true;
        movementInput = inputPlayer.Player1.Move.ReadValue<Vector2>();//Lee las teclas definida por el inputSystem

        playerInput = (new Vector3(movementInput.x, 0, movementInput.y));

        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;//El jugador camina hacia la direccino donde mira 

        movePlayer *= playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);//El jugador mira hacia la direccion en que camina

        SetGravity();
        Jump();
        Animacion();

        player.Move(movePlayer * Time.deltaTime);

    }
    /*Funcion para ejecutar la animacion presionando una tecla*/
    void Animacion()
    {
        if (inputPlayer.Player1.Move.IsPressed())
        {
            anim.SetFloat("EstaEnMovimiento", playerSpeed);
        }
        else
        {
            anim.SetFloat("EstaEnMovimiento", 0);
        }
    }
   /*Funcion para que verifica si el jugador salta o no*/
    void Jump()
    {
        if (player.isGrounded && inputPlayer.Player1.Jump.IsPressed())
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity * Time.deltaTime;
            anim.SetBool("EstaEnElSuelo", false);
        }
        else
        {
            anim.SetBool("EstaEnElSuelo", true);
        }
    }
    /*Se setea la gravedad*/
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
    /*Se obtiene las direcciones de la camara principal*/
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Agua")
    //    {
    //        //Debug.Log("Jugador1");
    //        //Destroy(gameObject);
    //        ReSpawn();
    //    }
    //}
    IEnumerator ReSpawn()
    {
        if (transform.position.y < threshold)
        {
            yield return 0;
            gameObject.transform.position = mainVecPos.position;
            player.enabled = false;

        }
    }
}
