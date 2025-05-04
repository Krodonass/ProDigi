using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PcCanvas : MonoBehaviour
{
    [SerializeField] private GameObject ControlsScreen;
    [SerializeField] private GameObject MailScreen;
    [SerializeField] private GameObject StartScreen;

    [SerializeField] private AudioSource MouseClick;

    public static event Action PCQuitEvent;
    
    void Start()
    {
        ControlsScreen.SetActive(false);
        MailScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    
    public static void TriggerPCQuit()
    {
        PCQuitEvent.Invoke();
    }

    //opens mail screen and closes every other screen
    public void OpenMailScreen()
    {
        ControlsScreen.SetActive(false);
        StartScreen.SetActive(false);
        MailScreen.SetActive(true);
    }
    
    //opens start screen and closes every other screen
    public void OpenStartScreen()
    {
        MailScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    
    //opens control screen and closes every other screen
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

    //plays mouse click sound
    public void MouseClickSound()
    {
        MouseClick.Play();
    }
}
