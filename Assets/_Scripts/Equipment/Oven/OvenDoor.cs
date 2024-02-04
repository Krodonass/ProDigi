using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public bool isOpenOvenDoor = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().isOpeneingOvenDoorGameManager && !isOpenOvenDoor)
        {
            openHatch();
            isOpenOvenDoor = true;
        } else if (gameManager.GetComponent<GameManager>().isClosingOvenDoorGameManager && isOpenOvenDoor)
        {
            Debug.Log("lol");
            closeHatch();
            isOpenOvenDoor = false;
        }
    }

    public void openHatch()
    {
        transform.Rotate(0, 0, 120);

    }

    public void closeHatch()
    {
        transform.Rotate(0, 0, -120);
    }
}
