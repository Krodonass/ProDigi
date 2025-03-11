using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailWidget : MonoBehaviour
{

    EmailData emailData;

    public TextMeshProUGUI SenderField;
    public TextMeshProUGUI SubjectField;

    public Button button;

    public event Action<EmailData> OnEmailClick;

    // Start is called before the first frame update
    void Start()
    {
        if(button){
            button.onClick.AddListener(SendEmail);
    }
        }

    // Update is called once per frame
    void Update()
    {
        
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
}
