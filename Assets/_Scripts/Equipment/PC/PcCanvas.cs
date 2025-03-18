using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PcCanvas : MonoBehaviour
{

    private Canvas canvas;

    [SerializeField] private GameObject ControlsScreen;
    [SerializeField] private GameObject MailScreen;
    [SerializeField] private GameObject StartScreen;

    [SerializeField] private AudioSource MouseClick;

    public static event Action PCQuitEvent;


    
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        if (canvas)
        {
            //canvas.worldCamera = Camera.current;
        }

        ControlsScreen.SetActive(false);
        MailScreen.SetActive(false);
        StartScreen.SetActive(true);
    }


    // Update is called once per frame
    public void PcQuit()
    {
        PCQuitEvent();
    }

    public static void TriggerPCQuit()
    {
        PCQuitEvent.Invoke();
    }

        //Opens the Mail overview
    public void OpenMailScreen()
    {
        ControlsScreen.SetActive(false);
        StartScreen.SetActive(false);
        MailScreen.SetActive(true);
    }


    //Goes back to Mainmenu
    public void OpenStartScreen()
    {
        MailScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        StartScreen.SetActive(true);
    }



    public void OpenControlsScreen()
    {
        MailScreen.SetActive(false);
        StartScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }


    //Opens a specific mail
    public void OpenMail()
    {

    }


    public void MouseClickSound()
    {
        MouseClick.Play();
    }
}
