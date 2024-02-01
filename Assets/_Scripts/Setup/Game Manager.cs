using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("PlayerObject")]
    public GameObject playerObject;
    [Header("PlayerMovement.cs")]

    [Header("PlayerCam")]
    public GameObject playerCam;
    [Header ("PickupController.cs")]
    public bool isCarryingGameManager;
    public bool isPickupableGameManager;
    public bool isUsableGameManager;
    public bool isRotatingObjectGameManager;
    public bool isGettingObjectInformationGameManager;
    public bool isUsingGloveboxGameManager;
    public bool isUsingHatchGameManager;

    [Header("OutterHatch")]
    public GameObject outterHatch;
    [Header("OutterHatch.cs")]
    public bool isOpeneingOutterHatchGameManager;
    public bool isClosingOutterHatchGameManager;
    public bool isOpenOutterHatchGameManager;

    [Header("Innter Hatch")]
    public GameObject innerHatch;
    [Header("InnterHatch.cs")]
    public bool isOpeneingInnerHatchGameManager;
    public bool isClosingInnerHatchGameManager;
    public bool isOpenInnerHatchGameManager;

    private void Awake()
    {
       Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // PlayerCam
        // PickupController.cs
        isCarryingGameManager = playerCam.GetComponent<PickupController>().isCarrying;
        isPickupableGameManager = playerCam.GetComponent<PickupController>().isPickupable;
        isUsableGameManager = playerCam.GetComponent<PickupController>().isUsable;
        isRotatingObjectGameManager = playerCam.GetComponent<PickupController>().isRotatingObject;
        isGettingObjectInformationGameManager = playerCam.GetComponent<PickupController>().isGettingObjectInformation;

        isUsingGloveboxGameManager = playerCam.GetComponent<PickupController>().isUsingGlovebox;

        isOpeneingOutterHatchGameManager = playerCam.GetComponent<PickupController>().isOpeningOutterHatch;
        isClosingOutterHatchGameManager = playerCam.GetComponent<PickupController>().isClosingOutterHatch;

        isOpeneingInnerHatchGameManager = playerCam.GetComponent<PickupController>().isOpeningInnerHatch;
        isClosingInnerHatchGameManager = playerCam.GetComponent<PickupController>().isClosingInnerHatch;

        // OutterHatch
        // OutterHatch.cs
        isOpenOutterHatchGameManager = outterHatch.GetComponent<OutterHatch>().isOpenOutterHatch;

        // InnerHatch
        // InnerHatch.cs
        isOpenInnerHatchGameManager = innerHatch.GetComponent<InnerHatch>().isOpenInnerHatch;

    }

    public enum GameState
    {

    }
}
