using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMailNotification : MonoBehaviour
{
    [SerializeField] private float rightElementPos = 190;
    [SerializeField] private float movingValue = 1;
    [SerializeField] private float movingSpeed = 1;

    private bool _mailNew = true;
    private bool _animStarted = false;

    private RectTransform _elementRectTransform;
    
    private void Start()
    {
        _elementRectTransform = GameManager.Instance.UIMailNotification.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("L pressed" + " "+_elementRectTransform.localPosition.x);
            UpdateUIMailNotification();    
        } 

    }

    private void UpdateUIMailNotification()
    { 
        if(_animStarted)
            return;
        
        if (_mailNew)
        {
            StartCoroutine(CloseUINotification());
            _mailNew = false; 
        }
       /* else
        {
            Destroy(this);
        }*/
    }
    
    private IEnumerator CloseUINotification()
    {
        _animStarted = true;
        
        while (_elementRectTransform.position.x < _elementRectTransform.position.x + rightElementPos)
        {
            _elementRectTransform.position += new Vector3(movingValue * movingSpeed * Time.deltaTime,0,0 );
            yield return null;
        }     
        
        _animStarted = false;
    }
}
