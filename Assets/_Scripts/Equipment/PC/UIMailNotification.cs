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
    
    private bool _animStarted;

    public static bool StartMailNew;
    public static bool CollectVacuumQuestMailNew;
    public static bool InsertBatteryQuestMailNew;
    public static bool TestFormBatteryQuestMailNew;

    private RectTransform _elementRectTransform;

    private Component _questManager;
    
    private void Start()
    {
        StartMailNew = false;
        CollectVacuumQuestMailNew = false;
        InsertBatteryQuestMailNew = false;
        TestFormBatteryQuestMailNew = false;
        
        _elementRectTransform = GameManager.Instance.UIMailNotification.GetComponent<RectTransform>();
        _activeElementPos = _elementRectTransform.localPosition.x;
        passiveElementPos = _activeElementPos + passiveElementPos;
    }
    
    public void CloseUIMailNotification()
    { 
        if (!_animStarted && MailScreen.NewMailCount == 1)
            StartCoroutine(ClosingUINotification());
    }

    public void OpenUINotification()
    {
        if (!_animStarted)
            StartCoroutine(OpeningUINotification());
    }
    
    private IEnumerator OpeningUINotification()
    {
        _animStarted = true;
        
        while (_elementRectTransform.localPosition.x > _activeElementPos)
        {
            _elementRectTransform.localPosition -= new Vector3(movingValue * movingSpeed * Time.deltaTime,0,0 );
            yield return null;
        }     
        
        _animStarted = false;
    }
    
    private IEnumerator ClosingUINotification()
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
