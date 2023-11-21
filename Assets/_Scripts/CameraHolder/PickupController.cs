using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GameObject keybindings;
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

    private void Update () 
    {
        mouseX = Input.GetAxis("Mouse X") * sensX;
        mouseY = Input.GetAxis("Mouse Y") * sensY;

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange) && raycastHit.transform.CompareTag("Pickupable") && !isCarrying)
        {
            highlight = raycastHit.transform;
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            } else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        } else
        {
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

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.GetComponent<Rigidbody>().tag != "Player")
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 30;
            //heldObjRB.transform.Rotate(0, 0, 0);
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;

        heldObjRB.AddForce(playerCharacter.velocity, ForceMode.Impulse);
        
        if (orientation.transform.rotation.eulerAngles.y >= 0 && orientation.transform.rotation.eulerAngles.y <= 89)
        {
            heldObjRB.AddForce(new Vector3(heldObjRB.velocity.x, mouseY * 10, -(mouseX * 5)), ForceMode.Impulse);
        } 
        else if (orientation.transform.rotation.eulerAngles.y >= 90 && orientation.transform.rotation.eulerAngles.y <= 179)
        {
            heldObjRB.AddForce(new Vector3(-(mouseX * 5), mouseY * 10, heldObjRB.velocity.z), ForceMode.Impulse);
        }
        else if (orientation.transform.rotation.eulerAngles.y >= 180 && orientation.transform.rotation.eulerAngles.y <= 269)
        {
            heldObjRB.AddForce(new Vector3(heldObjRB.velocity.x, mouseY * 10, mouseX * 5), ForceMode.Impulse);
        } 
        else if (orientation.transform.rotation.eulerAngles.y >= 270 && orientation.transform.rotation.eulerAngles.y <= 360)
        {
            heldObjRB.AddForce(new Vector3(mouseX * 5, mouseY * 10, heldObjRB.velocity.z), ForceMode.Impulse);
        }
        heldObj = null;
    }
}
