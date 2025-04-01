using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerCam : MonoBehaviour
{
    public GameManager gameManager;
    private Transform highlight;
    private RaycastHit raycastHit;
    public float sensX;
    public float sensY;
    public PlayerCam playercam;
    public Transform orientation;
    //For snapping back after leaving the PC
    public Vector3 StartPosition;
    public Quaternion StartRotation;
    
    float xRotation;
    float yRotation;

    private void Awake()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
        print("[PlayerCam] Awake");
    }
    
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        if(gameManager.isUsingPCGameManager){
            return;
        }
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
            }
                transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                orientation.rotation = Quaternion.Euler(0, yRotation, 0);
       }
        
    }
}
