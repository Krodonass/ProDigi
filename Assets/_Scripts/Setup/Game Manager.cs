using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool placedPatcellInTesterGameManager;

    public bool isOpeneingOutterHatchGameManager;
    public bool isClosingOutterHatchGameManager;
    public bool isOpeneingInnerHatchGameManager;
    public bool isClosingInnerHatchGameManager;
    public bool isOpeneingOvenDoorGameManager;
    public bool isClosingOvenDoorGameManager;

    public GameObject Dial;
    public bool isEvacuatingGameManager;
    public bool isFloodingGameManager;

    public bool isFloodedGameManager;
    public bool isEvacuatedGameManager;

    public bool assembleBaseGameManager;
    public bool assembleLowerPlungerGameManager;
    public bool assembleLowerCathodeGameManager;
    public bool assembleSleeveGameManager;
    public bool assembleUpperCathodeGameManager;
    public bool assembleUpperPlungerGameManager;
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
    public bool baseAssemblyPossibleGameManager;

    [Header("Pat Cell Lower Plunger")]
    public GameObject patCellLowerPlunger;
    public bool lowerPlungerAssemblyPossibleGameManager;

    [Header("Pat Cell Lower Cathode")]
    public GameObject patCellLowerCathode;
    public bool patCellLowerCathodeAssemblyPossibleGameManager;

    [Header("Pat Cell Sleeve")]
    public GameObject patCellSleeve;
    public bool patCellSleeveAssemblyPossibleGameManager;

    [Header("Pat Cell Upper Cathode")]
    public GameObject patCellUpperCathode;
    public bool patCellUpperCathodeAssemblyPossibleGameManager;

    [Header("Pat Cell Upper Plunger")]
    public GameObject patCellUpperPlunger;
    public bool patCellUpperPlungerAssemblyPossibleGameManager;

    [Header("Pat Cell Gear")]
    public GameObject patCellGear;
    public bool gearAssemblyPossibleGameManager;

    [Header("Pat Cell Brass Top")]
    public GameObject patCellBrassTop;
    public bool brassTopAssemblyPossibleGameManager;

    [Header("Pat Cell Assembly")]
    public GameObject patCellAssembly;
    public bool allAssembledGameManager;

    [Header("Pat Cell Assembly Materials")]
    public Material patCellAssemblyPossibleMaterial;
    public Material patCellAssemblyNotPossibleMaterial;

    [Header("QuestLog")]
    public TMP_Text Quastlog;

    public GameObject CellHatchTrigger;
    public bool basePlacedInOuterHatchGameManager;
    public bool lowerPlungerPlacedInOuterHatchGameManager;
    public bool lowerCathodePlacedInOuterHatchGameManager;
    public bool sleevePlacedInOuterHatchGameManager;
    public bool upperCathodePlacedInOuterHatchGameManager;
    public bool upperPlungerPlacedInOuterHatchGameManager;
    public bool gearPlacedInOuterHatchGameManager;
    public bool brassTopPlacedInOuterHatchGameManager;
    public bool allComponentsInHatchGameManager;
    public bool assembledPatCellInHatchGameManager;

    public GameObject WorkplaceTrigger;
    public bool allComponentsInGloveBoxGameManager;
    public bool assembledPatCellInWorkplaceGameManager;

    [Header("PatCell Tester Trigger")]
    public GameObject PatCellTesterTrigger;
    public bool PatCellTesterPlacableGameManager;

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
        assembleLowerPlungerGameManager = playerCam.GetComponent<PickupController>().assembleLowerPlunger;
        assembleLowerCathodeGameManager = playerCam.GetComponent<PickupController>().assembleLowerCathode;
        assembleSleeveGameManager = playerCam.GetComponent<PickupController>().assembleSleeve;
        assembleUpperCathodeGameManager = playerCam.GetComponent<PickupController>().assembleUpperCathode;
        assembleUpperPlungerGameManager = playerCam.GetComponent<PickupController>().assembleUpperPlunger;
        assembleGearGameManager = playerCam.GetComponent<PickupController>().assembleGear;
        assembleBrassTopGameManager = playerCam.GetComponent<PickupController>().assembleBrassTop;

        placedPatcellInTesterGameManager = playerCam.GetComponent<PickupController>().placedPatCallInTester;

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

        // Lower Plunger
        // CollisionAssemblyIdentifier.cs
        lowerPlungerAssemblyPossibleGameManager = patCellLowerPlunger.GetComponent<CollisionAssemblyIdentifier>().lowerPlungerAssemblyPossible;

        // Lower Cathode
        // CollisionAssemblyIdentifier.cs
        patCellLowerCathodeAssemblyPossibleGameManager = patCellLowerCathode.GetComponent<CollisionAssemblyIdentifier>().lowerCathodeAssemblyPossible;

        // Sleeve
        // CollisionAssemblyIdentifier.cs
        patCellSleeveAssemblyPossibleGameManager = patCellSleeve.GetComponent<CollisionAssemblyIdentifier>().sleeveAssemblyPossible;

        // Upper Cathode
        // CollisionAssemblyIdentifier.cs
        patCellUpperCathodeAssemblyPossibleGameManager = patCellUpperCathode.GetComponent<CollisionAssemblyIdentifier>().upperCathodeAssemblyPossible;

        // Upper Plunger
        // CollisionAssemblyIdentifier.cs
        patCellUpperPlungerAssemblyPossibleGameManager = patCellUpperPlunger.GetComponent<CollisionAssemblyIdentifier>().upperPlungerAssemblyPossible;

        // Gear
        // CollisionAssemblyIdentifier.cs
        gearAssemblyPossibleGameManager = patCellGear.GetComponent<CollisionAssemblyIdentifier>().gearAssemblyPossible;

        // BrassTop
        // CollisionAssemblyIdentifier.cs
        brassTopAssemblyPossibleGameManager = patCellBrassTop.GetComponent<CollisionAssemblyIdentifier>().brasstopAssemblyPossible;

        // PatCellAssembly
        // CollisionAssemblyIdentifier.cs
        allAssembledGameManager = patCellAssembly.GetComponent<PatCellAssembly>().allAssembled;

        // CellHatchTrigger
        // CellHatchTrigger.cs
        basePlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().baseInHatch;
        lowerPlungerPlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().lowerPlungerInHatch;
        lowerCathodePlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().lowerCathodeInHatch;
        sleevePlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().sleeveInHatch;
        upperCathodePlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().upperCathodeInHatch;
        upperPlungerPlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().upperPlungerInHatch;
        gearPlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().gearInHatch;
        brassTopPlacedInOuterHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().brassTopInHatch;

        allComponentsInHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().allComponentsInHatch;
        assembledPatCellInHatchGameManager = CellHatchTrigger.GetComponent<CellHatchTrigger>().assembledPatCellInHatch;

        allComponentsInGloveBoxGameManager = WorkplaceTrigger.GetComponent<WorkplaceTrigger>().allComponentsInWorkplace;
        assembledPatCellInWorkplaceGameManager = WorkplaceTrigger.GetComponent<WorkplaceTrigger>().assembledPatCellInWorkplace;


        isEvacuatingGameManager = playerCam.GetComponent<PickupController>().isEvacuating;
        isFloodingGameManager = playerCam.GetComponent<PickupController>().isFlooding;

        isFloodedGameManager = Dial.GetComponent<VacuumDial>().isFlooded;
        isEvacuatedGameManager = Dial.GetComponent<VacuumDial>().isEvacuated;

        if (allAssembledGameManager)
        {
            patCellAssembled.SetActive(true);
        }

        if (PatCellTesterTrigger)
        {
            PatCellTesterPlacableGameManager = PatCellTesterTrigger.GetComponent<PatcellTesterTriggerDetect>().placingPossible;
        }
    }

    public enum GameState
    {

    }
}
