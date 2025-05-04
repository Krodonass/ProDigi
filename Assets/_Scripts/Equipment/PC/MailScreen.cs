using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MailScreen : MonoBehaviour
{
    [SerializeField] private Transform ScrollViewContent;

    [SerializeField] private GameObject EmailPrefab;
    [SerializeField] private GameObject SpacingBarPrefab;

    [Tooltip("A List of EmailData from Emails you get by starting the game.")]
    [SerializeField] private List<EmailData> firstEmails;
    
    [Tooltip("A List of EmailData from Emails you get during the game.")]
    [SerializeField] private List<EmailData> secondaryEmails;
    
    void Start()
    {
        foreach(EmailData email in firstEmails)
        {
            GameObject NewEmailWidget = Instantiate(EmailPrefab, ScrollViewContent);
            EmailWidget emailWidget = NewEmailWidget.GetComponent<EmailWidget>();
            if(emailWidget) 
                emailWidget.LoadEmail(email);
            
            Instantiate(SpacingBarPrefab, ScrollViewContent);
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
            NextEmail(0);
    }

    public void NextEmail(int index)
    {
        GameObject NewEmailWidget = Instantiate(EmailPrefab, ScrollViewContent);
        EmailWidget emailWidget = NewEmailWidget.GetComponent<EmailWidget>();
        emailWidget.LoadEmail(secondaryEmails[index]);
        //emailWidget.LoadEmail(secondaryEmails.Find(item => item.name == "Email_02"));
        
        Instantiate(SpacingBarPrefab, ScrollViewContent);
    }
}
