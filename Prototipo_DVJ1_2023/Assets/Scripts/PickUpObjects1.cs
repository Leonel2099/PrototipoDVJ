using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObjects1 : MonoBehaviour
{
    /*Variables*/
    public GameObject ObjectToPickUp1;
    public GameObject PickedObject;
    public Transform interactionZone;
    private MovementPlayer1 inputPlayer1;

    private void Start()
    {
        inputPlayer1 = new MovementPlayer1();
        inputPlayer1.Player1.Enable();
    }
    void Update()
    {
        /*Corrobora si el player puede recoger un objeto*/
        if (ObjectToPickUp1 != null && ObjectToPickUp1.GetComponent<PickableObject1>().isPickable == true && PickedObject == null)
        {
            /*Corrobora si el player presiona el boton asignado, agarra el objeto */
            if (inputPlayer1.Player1.Grab.IsPressed())
            {
                PickedObject = ObjectToPickUp1;
                PickedObject.GetComponent<PickableObject1>().isPickable = false;
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
            if (inputPlayer1.Player1.Drop.IsPressed())
            {
                PickedObject.GetComponent<PickableObject1>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
