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

    [SerializeField] private List<EmailData> emailDataList;

    public static event Action<EmailData> OnNewEmail;


    // Start is called before the first frame update
    void Start()
    {
        foreach(EmailData email in emailDataList)
        {
            GameObject NewEmailWidget = Instantiate(EmailPrefab, ScrollViewContent);
            EmailWidget emailWidget = NewEmailWidget.GetComponent<EmailWidget>();
            if(emailWidget)
            { 
                emailWidget.OnEmailClick += ShowEmail;
                emailWidget.LoadEmail(email);
            } 
            
            GameObject NewSpacingBar = Instantiate(SpacingBarPrefab, ScrollViewContent);
        }

        OnNewEmail += OnAddEmail;
    }

    public void ShowEmail(EmailData email)
    {
    }
    
    //Call this to add a new EMail to the PCs
    public static void AddEmail(EmailData email)
    {
        OnNewEmail.Invoke(email);
    }
    
    //Will be called when the Event OnNewEmail is called
    private void OnAddEmail(EmailData email)
    {
        emailDataList.Add(email);
    }
}
