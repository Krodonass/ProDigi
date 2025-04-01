using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutterHatch : MonoBehaviour
{
    public GameManager gameManager;
    public bool isOpenOutterHatch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isOpeneingOutterHatchGameManager && !isOpenOutterHatch) {
            //Check if vakuum is Tube
            if (gameManager.isEvacuatedGameManager || gameManager.isEvacuatingGameManager)
            {
                return;
            }
            openHatch();
            isOpenOutterHatch = true;
        } else if (gameManager.isClosingOutterHatchGameManager && isOpenOutterHatch) 
        {
            closeHatch();
            isOpenOutterHatch = false;
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
