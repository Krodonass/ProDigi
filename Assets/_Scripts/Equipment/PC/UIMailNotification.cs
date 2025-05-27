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
    private bool _openedUINotification = true;

    public static bool StartMailNew;
    public static bool CollectVacuumQuestMailNew;
    public static bool InsertBatteryQuestMailNew;
    public static bool TestFormBatteryQuestMailNew;

    private RectTransform _elementRectTransform;

    private Component _questManager;

    public static bool OpenUINotificationAdded;
    
    private void Start()
    {
        _elementRectTransform = GameManager.Instance.UIMailNotification.GetComponent<RectTransform>();
        _activeElementPos = _elementRectTransform.localPosition.x;
        passiveElementPos = _activeElementPos + passiveElementPos;
        
        GameManager.Instance.GetComponent<QuestManager>().collectVacuumQuestResults.AddListener(GotNewMail); 
        GameManager.Instance.GetComponent<QuestManager>().insertBatteryQuestResults.AddListener(GotNewMail);   
        GameManager.Instance.GetComponent<QuestManager>().testFormBatteryQuestResults.AddListener(GotNewMail); 
        
        if(OpenUINotificationAdded)
            return;

        GameManager.Instance.GetComponent<QuestManager>().collectVacuumQuestResults.AddListener(StartOpenUINotification); 
        GameManager.Instance.GetComponent<QuestManager>().insertBatteryQuestResults.AddListener(StartOpenUINotification);   
        GameManager.Instance.GetComponent<QuestManager>().testFormBatteryQuestResults.AddListener(StartOpenUINotification);
    }
    
    public void UpdateUIMailNotification()
    { 
        if(_animStarted || !_mailNew)
            return;
        
        if (MailScreen.NewMailCount == 1)
        {
            StartCoroutine(CloseUINotification());
            _mailNew = false; 
        }
        else
        {
            _mailNew = false;
        }
    }

    public void GotNewMail()
    {
        _mailNew = true;
    }

    void StartOpenUINotification()
    {
        if(_openedUINotification)
            return;
        
        StartCoroutine(OpenUINotification());
        OpenUINotificationAdded = true;
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

        _openedUINotification = false;
        _animStarted = false;
    }
}
