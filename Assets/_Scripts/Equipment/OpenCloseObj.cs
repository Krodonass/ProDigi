using System;
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
        [SerializeField] private float interactDistance = 5f;
        
        [SerializeField] private Axis transformAxis;
        
        public float duration = 2f;
        
        private Quaternion _closeRotation;
        
        private Quaternion _openRotationX;       
        private Quaternion _openRotationY;
        private Quaternion _openRotationZ;
        
        private bool _isRotating = false;
        
        private bool _opens = false;


        private void Start()
        {
            _closeRotation = transform.localRotation;
            
            _openRotationX = _closeRotation * Quaternion.Euler(targetAngle, 0f, 0f);
            _openRotationY = _closeRotation * Quaternion.Euler(0f, targetAngle, 0f);
            _openRotationZ = _closeRotation * Quaternion.Euler(0f, 0f, targetAngle);
        }

        private void Update()
        {   
            //only for testing
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if(Camera.main == null)
                    return;
                
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, interactDistance))
                {
                    Debug.Log("Getroffen: " + hit.collider.name);
                    
                    if (hit.collider.CompareTag("Door"))
                    {
                        RotateOpenClose();
                    }
                }
            }
        }


        public void RotateOpenClose()
        {
            switch (transformAxis)
            {
                case Axis.X:
                    StartCoroutine(RotateInTime(_openRotationX));
                    break;
                
                case Axis.Y:
                    StartCoroutine(RotateInTime(_openRotationY));
                    break;
                
                case Axis.Z:
                    StartCoroutine(RotateInTime(_openRotationZ));
                    break;
            }
        }
        

        private IEnumerator RotateInTime(Quaternion openRotation)
        {
            if (_isRotating)
                yield break;

            _isRotating = true;
            _opens = !_opens;

            Quaternion startRotation = transform.localRotation;
            Quaternion endRotation = _opens ? openRotation : _closeRotation;

            float time = 0f;

            while (time < duration)
            {
                transform.localRotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            transform.localRotation = endRotation;
            
            _isRotating = false;
        }
    }
}
