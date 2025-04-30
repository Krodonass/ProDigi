using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class EmailWidget : MonoBehaviour
{
    EmailData emailData;
    
    public TextMeshProUGUI SenderField;
    public TextMeshProUGUI SubjectField;
    [SerializeField] private TextMeshProUGUI MailText;    
    
    [SerializeField] private float sizingValue = 0.1f;
    [SerializeField] private float sizingSpeed = 300f;
    [SerializeField] private float maxMailSize = 100f;
    private float minMailSize;

    private bool MailOpened = false;
    private bool animStarted = false;

    public Button button;

    public event Action<EmailData> OnEmailClick;
    
    void Start()
    {
        minMailSize = button.GetComponent<RectTransform>().sizeDelta.y;
        
        if(button)
        {
            button.onClick.AddListener(SendEmail);
        }
    }

    void SendEmail(){
        OnEmailClick(emailData);
    }

    public void LoadEmail(EmailData emailData){
        this.emailData = emailData;
        SenderField.text = emailData.sender;
        SubjectField.text = emailData.subject;
        MailText.text = emailData.content;
    }

    EmailData GetEmailData(){
        return emailData;
    }

    public void UpdateMailStatus()
    {
        if(animStarted)
            return;
        
        if (!MailOpened)
        {
            StartCoroutine(OpenMail());
            MailOpened = true; 
        }
        else 
        { 
            StartCoroutine(CloseMail()); 
            MailOpened = false;
        }
    }

    IEnumerator OpenMail()
    {
        animStarted = true;
        
        while (button.GetComponent<RectTransform>().sizeDelta.y < maxMailSize)
        {
            button.GetComponent<RectTransform>().sizeDelta += new Vector2(0, sizingValue * 10 * sizingSpeed * Time.deltaTime);
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>().localScale += new Vector3(0, sizingValue * sizingSpeed * Time.deltaTime, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
            yield return null;
        }

        animStarted = false;
    }

    IEnumerator CloseMail()
    {
        animStarted = true;
        
        while (button.GetComponent<RectTransform>().sizeDelta.y > minMailSize)
        {
            button.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, sizingValue * 10 * sizingSpeed * Time.deltaTime);
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>().localScale -= new Vector3(0, sizingValue * sizingSpeed * Time.deltaTime, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
            yield return null;
        }     
        
        animStarted = false;
    }
}
