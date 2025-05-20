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
        StartScreen.SetActive(true);

        //Mailscreen needs to stay active for creating Emails during the whole game!
        MailScreen.SetActive(true);
        SetAllMailScreenChildren(false);
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
        SetAllMailScreenChildren(true);
    }
    
    //opens start screen and closes every other screen
    public void OpenStartScreen()
    {
        SetAllMailScreenChildren(false);
        ControlsScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    
    //opens control screen and closes every other screen
    public void OpenControlsScreen()
    {
        SetAllMailScreenChildren(false);
        StartScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }
    
    //plays mouse click sound
    public void MouseClickSound(AudioSource audioSource)
    {
        audioSource.Play();
    }

    private void SetAllMailScreenChildren(bool state)
    {
        foreach (Transform child in MailScreen.transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}
