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
    
    [SerializeField] private float mailSize = 0.02f;
    [SerializeField] private float maxMailSize = 100f;
    private float minMailSize;

    private bool MailOpened = false;

    public TextMeshProUGUI SenderField;
    public TextMeshProUGUI SubjectField;

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
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            while (button.GetComponent<RectTransform>().sizeDelta.y <= maxMailSize)
            {
               button.GetComponent<RectTransform>().sizeDelta += new Vector2(0, mailSize*10);
               transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>().localScale += new Vector3(0, mailSize, 0);
               LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>()); 
            }
            
        }
    }

    void SendEmail(){
        OnEmailClick(emailData);
    }

    public void LoadEmail(EmailData emailData){
        this.emailData = emailData;
        SenderField.text = emailData.sender;
        SubjectField.text = emailData.subject;
    }

    EmailData GetEmailData(){
        return emailData;
    }

    public void OpenMail()
    {
        if (MailOpened)
            return;
        
        while (button.GetComponent<RectTransform>().sizeDelta.y<maxMailSize)
        {
            button.GetComponent<RectTransform>().sizeDelta += new Vector2(0, mailSize*10);
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>().localScale += new Vector3(0, mailSize, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
        }

        MailOpened = true;
        return;
        
        
    }
    
    /*public void CloseMail()
    {
        if (!MailOpened)
            return;
        
        while (button.GetComponent<RectTransform>().sizeDelta.y>minMailSize)
        {
            button.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, mailSize*10);
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<RectTransform>().localScale -= new Vector3(0, mailSize, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
        }

        MailOpened = false;
        return;
    }*/
}
