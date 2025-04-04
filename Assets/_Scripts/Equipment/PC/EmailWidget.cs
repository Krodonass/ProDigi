using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailWidget : MonoBehaviour
{

    EmailData emailData;
    

    [SerializeField] private float mailSize = 0.001f;

    public TextMeshProUGUI SenderField;
    public TextMeshProUGUI SubjectField;

    public Button button;
    [SerializeField] private RectTransform contentRectTransform;

    public event Action<EmailData> OnEmailClick;

    // Start is called before the first frame update
    void Start()
    {
        if(button)
        {
            button.onClick.AddListener(SendEmail);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            button.GetComponent<RectTransform>().sizeDelta += new Vector2(0,mailSize);
            //GetComponent<RectTransform>().sizeDelta += new Vector2(0,mailSize);
            //LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);
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
}
