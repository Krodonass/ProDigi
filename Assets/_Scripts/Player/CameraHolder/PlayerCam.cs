using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public GameObject gameManager;
    private Transform highlight;
    private RaycastHit raycastHit;
    public float sensX;
    public float sensY;
    public PlayerCam playercam;
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
        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * sensY;

        // rotate cam and orientation

       if (!playercam.GetComponent<PickupController>().isRotatingObject)
       {
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            if (!gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager)
            {
                transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            }
       }
        
    }
}
