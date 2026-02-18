using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Equipment 
{
    public class OpenCloseObj : MonoBehaviour
    {
        [SerializeField] private bool pushPull;
        [SerializeField] private bool rotateOpenClose;
        
        [SerializeField] private float targetAngle = 90f;
        [SerializeField] private float rotationSpeed = 90f; //degree per second
        
        [SerializeField] private float interactDistance = 5f;
        
        [SerializeField] private Axis transformAxis;
        
        private float t = 0f;
        public float duration = 2f;
        private Quaternion startRotation;
        private Quaternion targetRotation;
        
        private bool _opens = false;
        

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, interactDistance))
                {
                    Debug.Log("Getroffen: " + hit.collider.name);
                    
                    if (hit.collider.CompareTag("Door"))
                    {
                        RotateOpenClose();
                        Debug.Log(transform.eulerAngles.x);
                        Debug.Log(_opens);
                    }
                }
            }
        }


        public void RotateOpenClose()
        {
            switch (transformAxis)
            {
                case Axis.X:
                    break;
                
                case Axis.Y:
                    targetAngle = _opens ? transform.eulerAngles.y + targetAngle : transform.eulerAngles.y - targetAngle;
                    _opens = !_opens;
                    float newY = Mathf.MoveTowardsAngle(
                        transform.eulerAngles.y,
                        targetAngle,
                        rotationSpeed * Time.deltaTime
                    );
                    transform.rotation = Quaternion.Euler(0f, newY, 0f);
                    break;
                
                case Axis.Z:
                    targetAngle = _opens ? transform.eulerAngles.z + targetAngle : transform.eulerAngles.z - targetAngle;
                    _opens = !_opens;
                    float newZ = Mathf.MoveTowardsAngle(
                        transform.eulerAngles.z,
                        targetAngle,
                        rotationSpeed * Time.deltaTime
                    );
                    transform.rotation = Quaternion.Euler(0f, 0f, newZ);
                    break;
            }
        }
    }
}
