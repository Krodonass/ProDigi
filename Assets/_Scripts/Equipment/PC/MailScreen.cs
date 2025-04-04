using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MailScreen : MonoBehaviour
{
    public Transform ScrollViewContent;

    public TextMeshProUGUI  EmailTextWindow;
    public TextMeshProUGUI  EmailSendertTMP;
    public TextMeshProUGUI  EmailSubjectTMP;

    public GameObject EmailPrefab;

    public List<EmailData> emailDataList;

    public static event Action<EmailData> OnNewEmail;


    // Start is called before the first frame update
    void Start()
    {
        foreach(EmailData email in emailDataList){
            GameObject NewEmailWidget = Instantiate(EmailPrefab, ScrollViewContent);
            NewEmailWidget.transform.SetParent(ScrollViewContent);
            EmailWidget emailWidget = NewEmailWidget.GetComponent<EmailWidget>();
            if(emailWidget){
                emailWidget.OnEmailClick += ShowEmail;
                emailWidget.LoadEmail(email);
            }
        }

        OnNewEmail += OnAddEmail;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowEmail(EmailData email){
        if(EmailTextWindow){
            EmailTextWindow.text = email.content;
        }
        if(EmailSendertTMP){
            EmailSendertTMP.text = email.sender;
        }
        if(EmailSubjectTMP){
            EmailSubjectTMP.text = email.subject;
        }
    }


    //Call this to add a new EMail to the PCs
    public static void AddEmail(EmailData email){
        OnNewEmail.Invoke(email);
    }


    //Will be called when the Event OnNewEmail is called
    private void OnAddEmail(EmailData email){
        emailDataList.Add(email);
    }
}
