using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   
    public GameObject patCellAssembled;

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
    public GameObject heldObjInGloveBoxGameManager;
    public bool isUsingHatchGameManager;
    public bool isOpeneingOutterHatchGameManager;
    public bool isClosingOutterHatchGameManager;
    public bool isOpeneingInnerHatchGameManager;
    public bool isClosingInnerHatchGameManager;
    public bool isOpeneingOvenDoorGameManager;
    public bool isClosingOvenDoorGameManager;
    public bool assembleBaseGameManager;
    public bool assembleGearGameManager;
    public bool assembleBrassTopGameManager;

    [Header("OutterHatch")]
    public GameObject outterHatch;
    [Header("OutterHatch.cs")]
    public bool isOpenOutterHatchGameManager;

    [Header("Innter Hatch")]
    public GameObject innerHatch;
    [Header("InnterHatch.cs")]
    public bool isOpenInnerHatchGameManager;

    [Header("Oven Door")]
    public GameObject ovenDoor;
    [Header("OvenDoor.cs")]
    public bool isOpenOvenDoorGameManager;

    [Header("Pat Cell Base")]
    public GameObject patCellBase;
    [Header("OvenDoor.cs")]
    public bool baseAssemblyPossibleGameManager;

    [Header("Pat Cell Gear")]
    public GameObject patCellGear;
    [Header("OvenDoor.cs")]
    public bool gearAssemblyPossibleGameManager;

    [Header("Pat Cell Brass Top")]
    public GameObject patCellBrassTop;
    [Header("OvenDoor.cs")]
    public bool brassTopAssemblyPossibleGameManager;

    [Header("Pat Cell Assembly")]
    public GameObject patCellAssembly;
    [Header("OvenDoor.cs")]
    public bool allAssembledGameManager;


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

        isOpeneingOvenDoorGameManager = playerCam.GetComponent<PickupController>().isOpeningOvenDoor;
        isClosingOvenDoorGameManager = playerCam.GetComponent<PickupController>().isClosingOvenDoor;

        heldObjInGloveBoxGameManager = playerCam.GetComponent<PickupController>().heldObjectInGloveBox;

        assembleBaseGameManager = playerCam.GetComponent<PickupController>().assembleBase;
        assembleGearGameManager = playerCam.GetComponent<PickupController>().assembleGear;
        assembleBrassTopGameManager = playerCam.GetComponent<PickupController>().assembleBrassTop;

        // OutterHatch
        // OutterHatch.cs
        isOpenOutterHatchGameManager = outterHatch.GetComponent<OutterHatch>().isOpenOutterHatch;

        // InnerHatch
        // InnerHatch.cs
        isOpenInnerHatchGameManager = innerHatch.GetComponent<InnerHatch>().isOpenInnerHatch;

        // OvenDoor
        // OvenDoor.cs
        isOpenOvenDoorGameManager = ovenDoor.GetComponent<OvenDoor>().isOpenOvenDoor;

        // Base
        // CollisionAssemblyIdentifier.cs
        baseAssemblyPossibleGameManager = patCellBase.GetComponent<CollisionAssemblyIdentifier>().baseAssemblyPossible;

        // Gear
        // CollisionAssemblyIdentifier.cs
        gearAssemblyPossibleGameManager = patCellGear.GetComponent<CollisionAssemblyIdentifier>().gearAssemblyPossible;

        // BrassTop
        // CollisionAssemblyIdentifier.cs
        brassTopAssemblyPossibleGameManager = patCellBrassTop.GetComponent<CollisionAssemblyIdentifier>().brasstopAssemblyPossible;

        // PatCellAssembly
        // CollisionAssemblyIdentifier.cs
        allAssembledGameManager = patCellAssembly.GetComponent<PatCellAssembly>().allAssembled;

        

        if (allAssembledGameManager)
        {
            patCellAssembled.SetActive(true);
        }
    }

    public enum GameState
    {

    }
}
