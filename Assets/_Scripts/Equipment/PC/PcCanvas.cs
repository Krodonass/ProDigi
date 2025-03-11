using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PcCanvas : MonoBehaviour
{

    private Canvas canvas;

    public GameObject MailUI;

    public static event Action PCQuitEvent;



    
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        if (canvas)
        {
            //canvas.worldCamera = Camera.current;
        }
    }

    // Update is called once per frame
    public void PcQuit()
    {
        PCQuitEvent();
    }

    public static void TriggerPCQuit(){
        PCQuitEvent.Invoke();
    }

        //Opens the Mail overview
    public void OnMailUI(){
        MailUI.SetActive(!MailUI.activeSelf);
    }


    //Goes back to Mainmenu
    public void OpenMainMenu(){
        MailUI.SetActive(false);
    }

    //Opens a specific mail
    public void OpenMail(){

    }
}
