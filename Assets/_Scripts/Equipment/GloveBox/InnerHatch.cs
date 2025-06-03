using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHatch : Doors
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool isOpenInnerHatch = false;

    public Doors innerTray;
    

    public override void InvokeInteraction()
    {
        print("Toggle inner hatch");
        if (GameManager.Instance.isOpenOutterHatchGameManager) return;
        if(!GameManager.Instance.isEvacuatedGameManager) return;
        
        if(isOpenInnerHatch)
        {
            //Checks if try is open 
            if (innerTray)
            {
                if (innerTray.isTDopen == "n")
                {
                    closeHatch();
                }
            }
        } else
        {
            openHatch();
        }
    }

    public void openHatch()
    {
        GameManager.Instance.isOpenInnerHatchGameManager = true;
        transform.Rotate(0, -120, 0);
        isOpenInnerHatch = true;
    }

    public void closeHatch()
    {
        GameManager.Instance.isOpenInnerHatchGameManager = false;
        transform.Rotate(0, 120, 0);
        isOpenInnerHatch = false;
    }
}
