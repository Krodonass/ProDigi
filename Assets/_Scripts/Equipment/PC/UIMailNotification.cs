using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMailNotification : MonoBehaviour
{
    [SerializeField] private float passivElementPos = 190;
    [SerializeField] private float movingValue = 1f;
    [SerializeField] private float movingSpeed = 100;

    private bool _mailNew = true;
    private bool _animStarted = false;

    private RectTransform _elementRectTransform;
    
    private void Start()
    {
        _elementRectTransform = GameManager.Instance.UIMailNotification.GetComponent<RectTransform>();
        passivElementPos = _elementRectTransform.localPosition.x + passivElementPos;
    }

    //COUNTING MUST BE TESTED AGAIN WHEN ADDED TO THE BUTTON CLICK FUNCTION
    public void UpdateUIMailNotification()
    { 
        if(_animStarted || !_mailNew)
            return;
        
        if (MailScreen.NewMailCount == 1)
        {
            StartCoroutine(CloseUINotification());
            MailScreen.NewMailCount--;
            _mailNew = false; 
        }
        else
        {
            MailScreen.NewMailCount--;
            _mailNew = false;
        }
    }
    
    private IEnumerator CloseUINotification()
    {
        _animStarted = true;
        
        while (_elementRectTransform.localPosition.x < passivElementPos)
        {
            _elementRectTransform.localPosition += new Vector3(movingValue * movingSpeed * Time.deltaTime,0,0 );
            yield return null;
        }     
        
        _animStarted = false;
    }
}
