using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Equipment 
{
    public enum Axis { X, Y, Z }
    
    public class OpenCloseObj : MonoBehaviour
    {
        [SerializeField] private bool mustRotate  = false;  
   
        [SerializeField] private Axis transformAxis;        
        
        [SerializeField] private float targetTransform;
        [SerializeField] private float interactDistance = 5f;
        
        public float duration = 2f;
        
        private Quaternion _closeRotation;
        private readonly Quaternion[] _openRotations = new Quaternion[3];  
        
        private Vector3 _closePosition;
        private readonly Vector3[] _openPositions = new Vector3[3];
        
        private bool _isRotating = false;
        private bool _isMoving = false;
        
        private bool _rotatesToOpen = false;
        private bool _movesToOpen = false;


        private void Start()
        {
            _closeRotation = transform.localRotation;
            _closePosition = transform.localPosition;

            /* Creates the Quaternion and Vector3 for the opened object according
             to the targetTransform and transformed Axis (X = 0, Y = 1, Z = 2). */
            for (int i = 0; i < 3; i++)
            {
                Vector3 axisVector = Vector3.zero;
                axisVector[i] = 1f;

                _openRotations[i] = _closeRotation * Quaternion.AngleAxis(targetTransform, axisVector);

                _openPositions[i] = _closePosition + axisVector * targetTransform;
            }
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
                    Debug.Log("Hit: " + hit.collider.name);
                    
                    if (hit.collider.name == name)
                    {
                        OpenClose();
                    }
                }
            }
        }


        private void OpenClose()
        {
            if (mustRotate)
            {
                Quaternion rotation = transformAxis switch
                {
                    Axis.X => _openRotations[0],
                    Axis.Y => _openRotations[1],
                    Axis.Z => _openRotations[2],
                    _ => Quaternion.identity
                };

                StartCoroutine(RotateInTime(rotation));
            }
            else
            {
                Vector3 position = transformAxis switch
                {
                    Axis.X => _openPositions[0],
                    Axis.Y => _openPositions[1],
                    Axis.Z => _openPositions[2],
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
                transform.localPosition = Vector3.Slerp(startPosition, endPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            
            transform.localPosition = endPosition;

            _isMoving = false;
        }
    }
}
