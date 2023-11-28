using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public PlayerCam playercam;
    public TMP_Text mText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playercam.GetComponent<PickupController>().isPickupable)
        {
            mText.text = "press E to pick up";
        } else
        {
            mText.text = "";
        }
    }
}
