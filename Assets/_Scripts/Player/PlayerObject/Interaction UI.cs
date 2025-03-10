using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionUI : MonoBehaviour
{
    public PlayerCam playercam;
    public GameObject keybindings;
    public TMP_Text mText;
    public Canvas canvas;

    private void Start()
    {
        PickupController.PCStartEvent += PcCanvasOnPCStartEvent;
        PcCanvas.PCQuitEvent += PcCanvasOnPCQuitEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (playercam.GetComponent<PickupController>().isPickupable)
        {
            //mText.text = "press " + keybindings.GetComponent<KeysBindings>().grabKey + " to pick up";
        } else if (playercam.GetComponent<PickupController>().isGettingObjectInformation)
        {
            mText.text = playercam.GetComponent<PickupController>().objectInformationText;
        } else if (playercam.GetComponent<PickupController>().isUsable) 
        {
            //mText.text = "press " + keybindings.GetComponent<KeysBindings>().grabKey + " to use";
        } else
        {
            mText.text = "";
        }
    }
    
    void PcCanvasOnPCStartEvent(Transform PC)
    {
        if (canvas)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    
    void PcCanvasOnPCQuitEvent()
    {
        if (canvas)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
