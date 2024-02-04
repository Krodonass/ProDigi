using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutterHatch : MonoBehaviour
{
    public GameObject gameManager;
    public bool isOpenOutterHatch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().isOpeneingOutterHatchGameManager && !isOpenOutterHatch) {
            openHatch();
            isOpenOutterHatch = true;
        } else if (gameManager.GetComponent<GameManager>().isClosingOutterHatchGameManager && isOpenOutterHatch) 
        {
            closeHatch();
            isOpenOutterHatch = false;
        }
    }

    public void openHatch()
    {
        transform.Rotate(0, 120, 0);

    }

    public void closeHatch()
    {
        transform.Rotate(0, -120, 0);
    }
}
