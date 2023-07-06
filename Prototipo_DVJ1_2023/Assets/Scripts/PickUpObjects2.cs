using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObjects2 : MonoBehaviour
{
    /*Variables*/
    public GameObject ObjectToPickUp2;
    public GameObject PickedObject;
    public Transform interactionZone;
    private MovementPlayer2 inputPlayer2;

    private void Start()
    {
        inputPlayer2 = new MovementPlayer2();
        inputPlayer2.Player2.Enable();
    }
    void Update()
    {
        /*Corrobora si el player puede recoger un objeto*/
        if (ObjectToPickUp2 != null && ObjectToPickUp2.GetComponent<PickableObject2>().isPickable == true && PickedObject == null)
        {
            /*Corrobora si el player presiona el boton asignado, agarra el objeto */
            if (inputPlayer2.Player2.Grab.IsPressed())
            {
                PickedObject = ObjectToPickUp2;
                PickedObject.GetComponent<PickableObject2>().isPickable = false;
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
            if (inputPlayer2.Player2.Drop.IsPressed())
            {
                PickedObject.GetComponent<PickableObject2>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
