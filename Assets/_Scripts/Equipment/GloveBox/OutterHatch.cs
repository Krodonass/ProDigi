using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutterHatch : MonoBehaviour
{
    [HideInInspector]
    public bool isOpenOutterHatch = false;
    
    public Doors innerTray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isOpeneingOutterHatchGameManager && !isOpenOutterHatch) {
            //Check if vakuum is Tube
            if (GameManager.Instance.isEvacuatedGameManager || GameManager.Instance.isEvacuatingGameManager)
            {
                return;
            }
            openHatch();
            isOpenOutterHatch = true;
        } else if (GameManager.Instance.isClosingOutterHatchGameManager && isOpenOutterHatch) 
        {
            if (innerTray)
            {
                if (innerTray.isTDopen == "n")
                {
                    closeHatch();
                    isOpenOutterHatch = false;

                }
            }
        }
    }

    public void openHatch()
    {
        transform.Rotate(0, 200, 0);

    }

    public void closeHatch()
    {
        transform.Rotate(0, -200, 0);
    }
}
