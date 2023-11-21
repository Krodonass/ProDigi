using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    private Transform highlight;
    private RaycastHit raycastHit;
    public float sensX;
    public float sensY;
    //private PickupController pickupController;
    private float pickupRange = 5.0f;
    public Transform orientation;
  
    float xRotation;
    float yRotation;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Debug.Log(pickupController.GetComponent<PickupController>().isCarrying);
        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * sensY;

        yRotation += mouseX;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
