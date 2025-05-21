using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MailScreen : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private GameObject emailPrefab;
    [SerializeField] private GameObject spacingBarPrefab;

    [Tooltip("A List of EmailData from Emails you get by starting the game.")]
    [SerializeField] private List<EmailData> firstEmails;
    
    [Tooltip("A List of EmailData from Emails you get during the game.")]
    [SerializeField] private List<EmailData> secondaryEmails;

    public static int NewMailCount;
    
    private void Start()
    {
        // Creates the first emails by starting the email program on the pc. 
        foreach(EmailData email in firstEmails)
        {
            GameObject newEmailWidget = Instantiate(emailPrefab, scrollViewContent);
            newEmailWidget.transform.SetSiblingIndex(0);
            EmailWidget emailWidget = newEmailWidget.GetComponent<EmailWidget>();
            if(emailWidget) 
                emailWidget.LoadEmail(email);
            
            GameObject newSpacingBar = Instantiate(spacingBarPrefab, scrollViewContent);
            newSpacingBar.transform.SetSiblingIndex(1);
        }
        
        NewMailCount = firstEmails.Count;
    }

    //only for testing
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
            Debug.Log(NewMailCount);
        
        if(Input.GetKeyUp(KeyCode.H))
            NextEmail(0);
    }

    public void NextEmail(int index)
    {
        GameObject newEmailWidget = Instantiate(emailPrefab, scrollViewContent);
        newEmailWidget.transform.SetSiblingIndex(0);
        EmailWidget emailWidget = newEmailWidget.GetComponent<EmailWidget>();
        emailWidget.LoadEmail(secondaryEmails[index]);
        //emailWidget.LoadEmail(secondaryEmails.Find(item => item.name == "Email_02"));
        
        GameObject newSpacingBar = Instantiate(spacingBarPrefab, scrollViewContent);
        newSpacingBar.transform.SetSiblingIndex(1);
    }
}
