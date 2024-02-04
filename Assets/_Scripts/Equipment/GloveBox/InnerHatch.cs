using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHatch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public bool isOpenInnerHatch = false;
 
    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().isOpeneingInnerHatchGameManager && !isOpenInnerHatch)
        {
            openHatch();
            isOpenInnerHatch = true;
        } else if (gameManager.GetComponent<GameManager>().isClosingInnerHatchGameManager && isOpenInnerHatch)
        {
            closeHatch();
            isOpenInnerHatch = false;
        }
    }

    public void openHatch()
    {
        transform.Rotate(0, -120, 0);

    }

    public void closeHatch()
    {
        transform.Rotate(0, 120, 0);
    }
}
