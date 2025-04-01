using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHatch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public bool isOpenInnerHatch = false;

    public Doors innerTray;
 
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isOpeneingInnerHatchGameManager && !isOpenInnerHatch)
        {
            openHatch();
            isOpenInnerHatch = true;
        } else if (gameManager.isClosingInnerHatchGameManager && isOpenInnerHatch)
        {
            //Checks if try is open 
            if (innerTray)
            {
                if (innerTray.isTDopen == "n")
                {
                    closeHatch();
                    isOpenInnerHatch = false;
                }
            }

        }
    }

    public void openHatch()
    {
        Debug.Log("jo");
        transform.Rotate(0, -120, 0);
    }

    public void closeHatch()
    {
        transform.Rotate(0, 120, 0);
    }
}
