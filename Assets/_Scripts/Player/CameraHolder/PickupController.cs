using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupController : MonoBehaviour
{
    public GameObject keybindings;
    public GameObject holdAreaa;
    private Transform highlight;
    private RaycastHit raycastHit;

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] Rigidbody playerCharacter;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    public Transform orientation;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    public float sensX;
    public float sensY;

    public float mouseX;
    public float mouseY;

    public bool isCarrying;
    public bool isPickupable;
    public bool isUsable;
    public bool isRotatingObject = false;
    public bool isGettingObjectInformation = false;
    public string objectInformationText = "";

    private void Update () 
    {
        Debug.Log(holdAreaa.GetComponent<HoldArea>().ObjVelocity);
        mouseX = Input.GetAxis("Mouse X") * sensX;
        mouseY = Input.GetAxis("Mouse Y") * sensY;

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange) && raycastHit.transform.CompareTag("Pickupable") && !isCarrying && !isUsable)
        {
            highlight = raycastHit.transform;
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                isPickupable = true;
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            } else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange) && raycastHit.transform.CompareTag("Usable") && !isCarrying)
        {
            highlight = raycastHit.transform;
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                isUsable = true;
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            } else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        } else {
            isUsable = false;
            isPickupable = false;
            highlight = null;
        } 


        if (Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().grabKey))
        {
            if (heldObj == null) // No Object in Hand
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange))
                {
                    isCarrying = true;
                    PickupObject(raycastHit.transform.gameObject);
                }
            } else
            {
                isCarrying = false;
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
            if (Input.GetKey(keybindings.GetComponent<KeysBindings>().rotateKey))
            {
                isRotatingObject = true;
                RotateObject();
            } else
            {
                heldObjRB.transform.parent = holdArea;
                isRotatingObject = false;
            }
            if (Input.GetKey(keybindings.GetComponent<KeysBindings>().informationKey))
            {
                isGettingObjectInformation = true;
                objectInformationText = heldObj.GetComponent<ObjectInformation>().information;
            } else
            {
                isGettingObjectInformation = false;
            }
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void RotateObject()
    {
        heldObjRB.transform.parent = null;
        heldObjRB.transform.Rotate((-mouseY * 10), (-mouseX * 10), 0, Space.World);
    }

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.GetComponent<Rigidbody>().tag != "Player")
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 30;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        isRotatingObject = false;
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObjRB.transform.parent = null;
        heldObjRB.AddForce(holdAreaa.GetComponent<HoldArea>().ObjVelocity, ForceMode.Impulse);
        heldObj = null;
        holdArea.transform.localPosition = new Vector3(0, 0, 1f);
    }
}
