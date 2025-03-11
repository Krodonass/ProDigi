using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public PlayerCam playerCam;
    [Header ("PickupController.cs")]
    public bool isCarryingGameManager;
    public bool isPickupableGameManager;
    public bool isUsableGameManager;
    public bool isRotatingObjectGameManager;
    public bool isGettingObjectInformationGameManager;
    public bool isUsingGloveboxGameManager;
    public bool isUsingPCGameManager = false;
    public bool isCarryingPipetteGameManager;
    public bool activateLaserPointerGameManager;
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
    public bool assembleElectrolyteGameManager;
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

    [Header("Pat Cell Sleeve")]
    public GameObject patCellElectrolyte;
    public bool patCellElectrolyteAssemblyPossibleGameManager;

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

    public InteractionUI interactionUI;

    public GameObject drop;
    public bool electrolyAssembledGameManager;

    private void Awake()
    {
       Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PickupController.PCStartEvent += StartUsingPC;
        PcCanvas.PCQuitEvent += StopUsingPC;
    }

    // Update is called once per frame
    void Update()
    {
        electrolyAssembledGameManager = drop.GetComponent<Drop>().electolytAssembled;
        // PlayerCam
        // PickupController.cs
        PickupController pickupController = playerCam.gameObject.GetComponent<PickupController>();
        if (pickupController)
        {
            isCarryingGameManager = pickupController.isCarrying;
            isPickupableGameManager = pickupController.isPickupable;
            isUsableGameManager = pickupController.isUsable;
            isRotatingObjectGameManager = pickupController.isRotatingObject;
            isGettingObjectInformationGameManager = pickupController.isGettingObjectInformation;

            isUsingGloveboxGameManager = pickupController.isUsingGlovebox;

        isCarryingPipetteGameManager = playerCam.GetComponent<PickupController>().isCarryingPipette;
        activateLaserPointerGameManager = playerCam.GetComponent<PickupController>().activatePipetteLaserpointer;

        isOpeneingOutterHatchGameManager = playerCam.GetComponent<PickupController>().isOpeningOutterHatch;
        isClosingOutterHatchGameManager = playerCam.GetComponent<PickupController>().isClosingOutterHatch;
        
            isCarryingPipetteGameManager = pickupController.isCarryingPipette;
            isOpeneingOutterHatchGameManager = pickupController.isOpeningOutterHatch;
            isClosingOutterHatchGameManager = pickupController.isClosingOutterHatch;

            isOpeneingInnerHatchGameManager = pickupController.isOpeningInnerHatch;
            isClosingInnerHatchGameManager = pickupController.isClosingInnerHatch;

            isOpeneingOvenDoorGameManager = pickupController.isOpeningOvenDoor;
            isClosingOvenDoorGameManager = pickupController.isClosingOvenDoor;

            heldObjInGloveBoxGameManager = pickupController.heldObjectInGloveBox;

            assembleBaseGameManager = pickupController.assembleBase;
            assembleLowerPlungerGameManager = pickupController.assembleLowerPlunger;
            assembleLowerCathodeGameManager = pickupController.assembleLowerCathode;
            assembleSleeveGameManager = pickupController.assembleSleeve;
            assembleUpperCathodeGameManager = pickupController.assembleUpperCathode;
            assembleUpperPlungerGameManager = pickupController.assembleUpperPlunger;
            assembleGearGameManager = pickupController.assembleGear;
            assembleBrassTopGameManager = pickupController.assembleBrassTop;

            placedPatcellInTesterGameManager = pickupController.placedPatCallInTester;
            
            isEvacuatingGameManager = pickupController.isEvacuating;
            isFloodingGameManager = pickupController.isFlooding;
        }


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

    //Call when you use a PC
    public void StartUsingPC(Transform PC){
        isUsingPCGameManager = true;
        PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if(playerMovement){
            playerMovement.StopMovement();
        }
        playerCam.StartPosition = playerCam.transform.position;
        playerCam.transform.DOMove(PC.position, .5f);
        playerCam.transform.DORotate(PC.rotation.eulerAngles, 0.5f);
        if(interactionUI){
                interactionUI.gameObject.SetActive(false);
        }
    }

    public void StopUsingPC(){
        playerCam.transform.DOMove(playerCam.StartRotation.eulerAngles, 0.5f);
        playerCam.transform.DOMove(playerCam.StartPosition, .5f).OnComplete(() =>
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if(interactionUI){
                interactionUI.gameObject.SetActive(true);
            }
            isUsingPCGameManager = false;
        });
        return;
    }

}
