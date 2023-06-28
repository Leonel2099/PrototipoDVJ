using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove2 : MonoBehaviour
{
    private MovementPlayer2 _myInput;
    public CharacterController player;
    private Vector2 movementInput;

    private Vector3 playerInput;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    private GameObject grabbedObject;
    private bool isGrabbing;
    private float originalPlayerSpeed;

    private void Start()
    {
        _myInput = new MovementPlayer2();
        _myInput.Player2.Enable();
        player = GetComponent<CharacterController>();
        originalPlayerSpeed = playerSpeed;
    }

    void Update()
    {
        movementInput = _myInput.Player2.Move.ReadValue<Vector2>();

        playerInput = (new Vector3(movementInput.x, 0, movementInput.y));

        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer *= playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);
        if (_myInput.Player2.Interaction.IsPressed())
        {
            if (!isGrabbing)
            {
                GameObject nearbyObject = CheckForNearbyObject();

                if (nearbyObject != null)
                {
                    GrabObject(nearbyObject);
                }
            }
        }
        else if (isGrabbing)
        {
            DropObject();
        }

    }
    void GrabObject(GameObject obj)
    {
        grabbedObject = obj;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.SetParent(transform);
        isGrabbing = true;

        playerSpeed = originalPlayerSpeed * 0.5f;
    }

    void DropObject()
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        isGrabbing = false;

        playerSpeed = originalPlayerSpeed;
    }

    GameObject CheckForNearbyObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Grabbable"))
            {
                return collider.gameObject;
            }
        }

        return null;
    }
    void PlayerSkills()
    {
        if (player.isGrounded && _myInput.Player2.Jump.IsPressed())
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity * Time.deltaTime;
        }
    }
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
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
