using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObjects : MonoBehaviour
{
    /*Variables*/
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    private MovementPlayer1 inputPlayer1;
    private MovementPlayer2 inputPlayer2;

    private void Start()
    {
        inputPlayer1 = new MovementPlayer1();
        inputPlayer1.Player1.Enable();
        inputPlayer2 = new MovementPlayer2();
        inputPlayer2.Player2.Enable();
    }
    void Update()
    {
        /*Corrobora si el player puede recoger un objeto*/
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            /*Corrobora si el player presiona el boton asignado, agarra el objeto */
            if (inputPlayer1.Player1.Grab.IsPressed() || inputPlayer2.Player2.Grab.IsPressed())
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        /*El player ya recogio el objeto*/
        else if (PickedObject != null)
        {
            /*Corrobora si el player presiona el boton asignado, suelta el objeto */
            if (inputPlayer1.Player1.Drop.IsPressed() || inputPlayer2.Player2.Drop.IsPressed())
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
