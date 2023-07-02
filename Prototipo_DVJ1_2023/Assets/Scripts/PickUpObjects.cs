using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject; // objeto que agarramos
    public Transform interactionZone; // pone en esta zona
    private MovementPlayer1 _myInput;
    public BoxCollider cuadraditouwu;


    private void Start()
    {
        _myInput = new MovementPlayer1();
        _myInput.Player1.Enable();
        cuadraditouwu = GetComponent<BoxCollider>();
        cuadraditouwu.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (_myInput.Player1.Interaction.IsPressed())
            {
                cuadraditouwu.enabled = true;
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true; // no tiene accion
            }
        }

        else if (PickedObject != null)
        {
            if (_myInput.Player1.Interaction.IsPressed())
            {
                cuadraditouwu.enabled = false;
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false; // no tiene accion 
                PickedObject = null;
            }
        }
    }
}
