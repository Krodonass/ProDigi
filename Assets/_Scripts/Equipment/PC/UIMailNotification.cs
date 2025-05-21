using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UIMailNotification : MonoBehaviour
{
    [SerializeField] private float passiveElementPos = 190;
    [SerializeField] private float movingValue = 1f;
    [SerializeField] private float movingSpeed = 150;

    private float _activeElementPos;
    
    private bool _mailNew = true;
    private bool _animStarted;

    private RectTransform _elementRectTransform;

    private Component _questManager;
    
    private void Start()
    {
        _elementRectTransform = GameManager.Instance.UIMailNotification.GetComponent<RectTransform>();
        _activeElementPos = _elementRectTransform.localPosition.x;
        passiveElementPos = _activeElementPos + passiveElementPos;
        
        GameManager.Instance.GetComponent<QuestManager>().insertBatteryQuestResults.AddListener(GotNewMail);
    }

    //COUNTING MUST BE TESTED AGAIN WHEN ADDED TO THE BUTTON CLICK FUNCTION
    public void UpdateUIMailNotification()
    { 
        if(_animStarted)
            return;
        
        if (!_mailNew)
        {
            //StartCoroutine(OpenUINotification());
            //_mailNew = true;
            return;
        }        
        
        if (MailScreen.NewMailCount == 1)//&& _mailNew)
        {
            StartCoroutine(CloseUINotification());
            MailScreen.NewMailCount--;
            _mailNew = false; 
        }
        else //if (_mailNew)
        {
            MailScreen.NewMailCount--;
            _mailNew = false;
        }
    }

    public void GotNewMail()
    {
        _mailNew = true;
    }
    
    private IEnumerator OpenUINotification()
    {
        _animStarted = true;
        
        while (_elementRectTransform.localPosition.x > _activeElementPos)
        {
            _elementRectTransform.localPosition -= new Vector3(movingValue * movingSpeed * Time.deltaTime,0,0 );
            yield return null;
        }     
        
        _animStarted = false;
    }
    
    private IEnumerator CloseUINotification()
    {
        _animStarted = true;
        
        while (_elementRectTransform.localPosition.x < passiveElementPos)
        {
            _elementRectTransform.localPosition += new Vector3(movingValue * movingSpeed * Time.deltaTime,0,0 );
            yield return null;
        }     
        
        _animStarted = false;
    }
}
