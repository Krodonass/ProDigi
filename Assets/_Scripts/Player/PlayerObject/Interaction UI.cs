using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InteractionUI : MonoBehaviour
{
    public PlayerCam playercam;
    public GameObject keybindings;
    public TMP_Text mText;
    public Canvas canvas;

    public TMP_Text InteractableKey;
    public Image MouseInteraction;
    
    public TMP_Text ExitKeyNotification;

    private void Start()
    {
        PickupController.PCStartEvent += PcCanvasOnPCStartEvent;
        PcCanvas.PCQuitEvent += PcCanvasOnPCQuitEvent;
        PickupController.OnHoverInteractable += ShowInterActionKey;
        PickupController.OnNotHoverInteractable += HideInteractionKey;
        CollisionAssemblyIdentifier.ShowMouseInput += ShowMouseInteraction;
        CollisionAssemblyIdentifier.HideMouseInput += HideMouseInteraction;
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
        
        if (Input.GetMouseButtonDown(0))
        {
            HideMouseInteraction();
        }

        if (GameManager.Instance.isUsingPCGameManager || GameManager.Instance.isUsingGloveboxGameManager || GameManager.Instance.isUsingPauseMenuGameManager)
        {
            if (ExitKeyNotification)
            {
                if (GameManager.Instance.isUsingPauseMenuGameManager)
                {
                    ExitKeyNotification.gameObject.SetActive(false);
                    return;
                }
                    
                ExitKeyNotification.gameObject.SetActive(true);
            }
        }
        else
        {
            if (ExitKeyNotification)
            {
                ExitKeyNotification.gameObject.SetActive(false);
            }
        }
    }
    
    void PcCanvasOnPCStartEvent(Transform PC)
    {
        if (canvas)
        {
            canvas.gameObject.SetActive(false);
            InteractableKey.gameObject.SetActive(false);
        }
    }
    
    void PcCanvasOnPCQuitEvent()
    {
        if (canvas)
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void ShowInterActionKey()
    {
        InteractableKey.gameObject.SetActive(true);
    }

    void HideInteractionKey()
    {
        InteractableKey.gameObject.SetActive(false);
    }

    void ShowMouseInteraction()
    {
        MouseInteraction.gameObject.SetActive(true);
    }

    void HideMouseInteraction()
    {
        MouseInteraction.gameObject.SetActive(false);
    }
}
