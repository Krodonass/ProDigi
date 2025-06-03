using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EmailWidget : MonoBehaviour
{
    //EmailData emailData;
    
    [SerializeField] private TextMeshProUGUI senderField;
    [SerializeField] private TextMeshProUGUI subjectField;
    [SerializeField] private TextMeshProUGUI mailText; 
    
    [SerializeField] private Button button;

    [SerializeField] private Image mailViewSymbol;
    
    [SerializeField] private float sizingValue = 0.1f;
    [SerializeField] private float sizingSpeed = 300f;
    
    private float _maxMailSize;
    private float _minMailSize;

    private bool _mailOpened;
    private bool _animStarted;

    private int _questOrder;

    private RectTransform _buttonRectTransform;
    private RectTransform _nextChildRectTransform;
    private RectTransform _parentRectTransform;
    private Transform _parent;
    
    void Start()
    {
        _parent = transform.parent;
        _buttonRectTransform = button.GetComponent<RectTransform>();
        _nextChildRectTransform = _parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>();
        _parentRectTransform = _parent.GetComponent<RectTransform>();
        
        _minMailSize = button.GetComponent<RectTransform>().sizeDelta.y;

        mailText.gameObject.SetActive(false);
        _parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Image>().enabled = false;
    }

    public void LoadEmail(EmailData emailData)
    {
        _maxMailSize = emailData.maxMailSize;
        senderField.text = emailData.sender;
        subjectField.text = emailData.subject;
        mailText.text = emailData.content;
        _questOrder = emailData.questOrder;
    }
    
    public void UpdateMailView()
    {
        if(_animStarted)
            return;
        
        if (!_mailOpened)
        {
            StartCoroutine(OpenMailAnim());
            _mailOpened = true; 
        }
        else 
        { 
            StartCoroutine(CloseMailAnim()); 
            _mailOpened = false;
        }
    }

    private IEnumerator OpenMailAnim()
    {
        _animStarted = true;
        
        while (_buttonRectTransform.sizeDelta.y < _maxMailSize)
        {
            _buttonRectTransform.sizeDelta += new Vector2(0, sizingValue * 10 * sizingSpeed * Time.deltaTime);
            _nextChildRectTransform.localScale += new Vector3(0, sizingValue * sizingSpeed * Time.deltaTime, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRectTransform);
            yield return null;
        }
        
        mailText.gameObject.SetActive(true);
        mailViewSymbol.transform.Rotate(0,0,180);
        
        _animStarted = false;
    }

    private IEnumerator CloseMailAnim()
    {
        _animStarted = true;
        mailText.gameObject.SetActive(false);      
        
        while (_buttonRectTransform.sizeDelta.y > _minMailSize)
        {
            _buttonRectTransform.sizeDelta -= new Vector2(0, sizingValue * 10 * sizingSpeed * Time.deltaTime);
            _nextChildRectTransform.localScale -= new Vector3(0, sizingValue * sizingSpeed * Time.deltaTime, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRectTransform);
            yield return null;
        }     

        mailViewSymbol.transform.Rotate(0,0,-180);
        _animStarted = false;
    }

    public void SetMailNewStatus()
    { 
        switch (_questOrder)
        {
            case 0:
                if(UIMailNotification.StartMailNew) 
                    return;
               
                UIMailNotification.StartMailNew = true;
                break;
           
            case 1:
                if (UIMailNotification.CollectVacuumQuestMailNew)
                    return;
               
                UIMailNotification.CollectVacuumQuestMailNew = true;
                break;
           
            case 2:
                if (UIMailNotification.InsertBatteryQuestMailNew)
                    return;
               
                UIMailNotification.InsertBatteryQuestMailNew = true;
                break;
           
            case 3:
                if (UIMailNotification.TestFormBatteryQuestMailNew)
                    return;
               
                UIMailNotification.TestFormBatteryQuestMailNew = true;
                break;
        }
    }

    public void UpdateMailNewStatus()
    {
        switch (_questOrder)
        {
            case 0:
                if(!UIMailNotification.StartMailNew)
                    return;
               
                UIMailNotification.StartMailNew = false;
                GameManager.Instance.GetComponent<UIMailNotification>().CloseUIMailNotification();
                MailScreen.NewMailCount--;
                break;
           
            case 1:
                if (!UIMailNotification.CollectVacuumQuestMailNew)
                    return;
               
                UIMailNotification.CollectVacuumQuestMailNew = false;
                GameManager.Instance.GetComponent<UIMailNotification>().CloseUIMailNotification();
                MailScreen.NewMailCount--;
                break;
           
            case 2:
                if (!UIMailNotification.InsertBatteryQuestMailNew)
                    return;
               
                UIMailNotification.InsertBatteryQuestMailNew = false;
                GameManager.Instance.GetComponent<UIMailNotification>().CloseUIMailNotification();
                MailScreen.NewMailCount--;
                break;
           
            case 3:
                if (!UIMailNotification.TestFormBatteryQuestMailNew)
                    return;
               
                UIMailNotification.TestFormBatteryQuestMailNew = false;
                GameManager.Instance.GetComponent<UIMailNotification>().CloseUIMailNotification();
                MailScreen.NewMailCount--;
                break;
        }  
    }
    
}
