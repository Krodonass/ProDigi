using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public PlayerCam playercam;
    public GameObject keybindings;
    public TMP_Text mText;

    // Update is called once per frame
    void Update()
    {
        if (playercam.GetComponent<PickupController>().isPickupable)
        {
            mText.text = "press " + keybindings.GetComponent<KeysBindings>().grabKey + " to pick up";
        } else if (playercam.GetComponent<PickupController>().isGettingObjectInformation)
        {
            mText.text = playercam.GetComponent<PickupController>().objectInformationText;
        } else if (playercam.GetComponent<PickupController>().isUsable) 
        {
            mText.text = "press " + keybindings.GetComponent<KeysBindings>().grabKey + " to use";
        } else
        {
            mText.text = "";
        }
    }
}
