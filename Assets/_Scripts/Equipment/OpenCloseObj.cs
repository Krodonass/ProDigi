using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Equipment 
{
    public enum Axis { X, Y, Z }
    
    public class OpenCloseObj : MonoBehaviour
    {
        [SerializeField] private float targetAngle = 90f;
        [SerializeField] private float targetMovement = 90f;
        
        [SerializeField] private float interactDistance = 5f;
        
        [SerializeField] private Axis transformAxis;
        [SerializeField] private bool mustRotate = false;
        
        public float duration = 2f;
        
        private Quaternion _closeRotation;
        
        private Quaternion _openRotationX;       
        private Quaternion _openRotationY;
        private Quaternion _openRotationZ;
        
        private Vector3 _closePosition;
        
        private Vector3 _openPositionX;       
        private Vector3 _openPositionY;
        private Vector3 _openPositionZ; 
        
        private bool _isRotating = false;
        private bool _isMoving = false;
        
        private bool _rotatesToOpen = false;
        private bool _movesToOpen = false;


        private void Start()
        {
            _closeRotation = transform.localRotation;
            
            _openRotationX = _closeRotation * Quaternion.Euler(targetAngle, 0f, 0f);
            _openRotationY = _closeRotation * Quaternion.Euler(0f, targetAngle, 0f);
            _openRotationZ = _closeRotation * Quaternion.Euler(0f, 0f, targetAngle);
            
            _closePosition = transform.localPosition;
            
            _openPositionX = _closePosition + new Vector3(targetMovement, 0f, 0f);
            _openPositionY = _closePosition + new Vector3(0f, targetMovement, 0f);
            _openPositionZ = _closePosition + new Vector3(0f, 0f, targetMovement);
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
                        OpenClose();
                    }
                }
            }
        }


        public void OpenClose()
        {
            if (mustRotate)
            {
                Quaternion rotation = transformAxis switch
                {
                    Axis.X => _openRotationX,
                    Axis.Y => _openRotationY,
                    Axis.Z => _openRotationZ,
                    _ => Quaternion.identity
                };

                StartCoroutine(RotateInTime(rotation));
            }
            else
            {
                Vector3 position = transformAxis switch
                {
                    Axis.X => _openPositionX,
                    Axis.Y => _openPositionY,
                    Axis.Z => _openPositionZ,
                    _ => Vector3.zero
                };

                StartCoroutine(PushPullInTime(position));
            }
        }
        
        
        private IEnumerator RotateInTime(Quaternion openRotation)
        {
            if (_isRotating)
                yield break;

            _isRotating = true;
            _rotatesToOpen = !_rotatesToOpen;

            Quaternion startRotation = transform.localRotation;
            Quaternion endRotation = _rotatesToOpen ? openRotation : _closeRotation;

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


        private IEnumerator PushPullInTime(Vector3 openPosition)
        { 
            if (_isMoving) 
                yield break;
            
            _isMoving = true;
            _movesToOpen = !_movesToOpen;

            Vector3 startPosition = transform.localPosition;
            Vector3 endPosition = _movesToOpen ? openPosition : _closePosition;
            
            float time = 0f;

            while (time < duration)
            {
                transform.position = Vector3.Slerp(startPosition, endPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            
            transform.localPosition = endPosition;

            _isMoving = false;
        }
    }
}
