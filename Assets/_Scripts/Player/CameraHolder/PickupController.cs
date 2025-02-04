using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PickupController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject keybindings;
    public GameObject holdAreaa;
    public GameObject heldObjectInGloveBox;
    private Transform highlight;
    private RaycastHit raycastHit;
    public Space space;
    public Vector3 relative;

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] Rigidbody playerCharacter;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    public Transform orientation;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    public float sensX;
    public float sensY;

    public float mouseX;
    public float mouseY;

    public bool isPickupable;
    public bool isCarrying;

    public bool isUsable;
    public bool isUsing;
    public bool isUsingGlovebox;
    public bool isPlacable;

    public bool assembleBase;
    public bool assembleLowerPlunger;
    public bool assembleLowerCathode;
    public bool assembleSleeve;
    public bool assembleUpperCathode;
    public bool assembleUpperPlunger;
    public bool assembleGear;
    public bool assembleBrassTop;

    public bool placedPatCallInTester; 

    public bool isOpeningOutterHatch;
    public bool isClosingOutterHatch;

    public bool isOpeningInnerHatch;
    public bool isClosingInnerHatch;

    public bool isOpeningOvenDoor;
    public bool isClosingOvenDoor;

    public bool isEvacuating;
    public bool isFlooding;


    public bool isRotatingObject = false;
    public bool isGettingObjectInformation = false;
    public string objectInformationText = "";

    public float yRotationMultiplier;
    public float zRotationMultiplier;

    private void Update()
{
    // Komponenten und häufig verwendete Werte cachen
    KeysBindings keysBindings = keybindings.GetComponent<KeysBindings>();
    GameManager gm = gameManager.GetComponent<GameManager>();
    float currentY = transform.rotation.eulerAngles.y;
    
    // Mausbewegung
    mouseX = Input.GetAxis("Mouse X") * sensX;
    mouseY = Input.GetAxis("Mouse Y") * sensY;

    // yRotationMultiplier berechnen
    if (currentY <= 180f)
    {
        yRotationMultiplier = Remap(currentY, 0f, 180f, 10f, -10f);
    }
    else
    {
        yRotationMultiplier = Remap(currentY, 180f, 360f, -10f, 10f);
    }

    // zRotationMultiplier berechnen
    if (currentY > 90f && currentY <= 270f)
    {
        zRotationMultiplier = Remap(currentY, 90f, 270f, -10f, 10f);
    }
    else if (currentY < 90f)
    {
        zRotationMultiplier = Remap(currentY, 90f, 0f, -10f, 0f);
    }
    else if (currentY > 270f && currentY <= 360f)
    {
        zRotationMultiplier = Remap(currentY, 270f, 360f, 10f, 0f);
    }

    // Falls es bereits ein hervorgehobenes Objekt gibt, deaktiviere dessen Outline
    if (highlight != null)
    {
        Outline oldOutline = highlight.GetComponent<Outline>();
        if (oldOutline != null)
        {
            oldOutline.enabled = false;
        }
        highlight = null;
    }

    // Einen Raycast durchführen und Ergebnis zwischenspeichern
    bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pickupRange);

    // Überprüfe, ob das getroffene Objekt pickupable oder usable ist
    if (hasHit)
    {
        if (hit.transform.CompareTag("Pickupable") && !isCarrying && !isUsable)
        {
            highlight = hit.transform;
            EnableOutline(highlight);
            isPickupable = true;
        }
        else if (hit.transform.CompareTag("Usable") && !isCarrying)
        {
            highlight = hit.transform;
            EnableOutline(highlight);
            isUsable = true;
        }else
        {
            isPickupable = false;
            isUsable = false;
        }
    }
    else
    {
        isPickupable = false;
        isUsable = false;
    }

    // Grab-Input verarbeiten
    if (Input.GetKeyDown(keysBindings.grabKey))
    {
        if (heldObj == null)
        {
            if (hasHit && hit.transform.CompareTag("Pickupable"))
            {
                PickupObject(hit.transform.gameObject);
            }
        }
        else
        {
            DropObject();
        }

        // Weitere Interaktionen, falls kein Objekt in der Hand ist
        if (heldObj == null && hasHit)
        {
            // Beispiel: Wenn das getroffene Objekt "glass" heißt, Glovebox aktivieren
            if (hit.collider.name == "glass")
            {
                isUsingGlovebox = true;
            }
            else if (hit.collider.name == "PC")
            {
                print("HackerMan!!!");
            }else
            {
                //open or closes Doors
                Doors doors = hit.transform.GetComponent<Doors>();
                if (doors)
                {
                    doors.InvokeInteraction();
                }
            }

            if (isUsable)
            {
                if (hit.collider.name == "OutterHatch")
                {
                    if (!gm.isOpenOutterHatchGameManager)
                    {
                        isOpeningOutterHatch = true;
                        isClosingOutterHatch = false;
                    }
                    else
                    {
                        isClosingOutterHatch = true;
                        isOpeningOutterHatch = false;
                    }
                }
                else if (hit.collider.name == "InnerHatch")
                {
                    if (!gm.isOpenInnerHatchGameManager)
                    {
                        isOpeningInnerHatch = true;
                        isClosingInnerHatch = false;
                    }
                    else
                    {
                        isClosingInnerHatch = true;
                        isOpeningInnerHatch = false;
                    }
                }
                else if (hit.collider.name == "OvenDoor")
                {
                    if (!gm.isOpenOvenDoorGameManager)
                    {
                        isOpeningOvenDoor = true;
                        isClosingOvenDoor = false;
                    }
                    else
                    {
                        isClosingOvenDoor = true;
                        isOpeningOvenDoor = false;
                    }
                }
                else if (hit.collider.name == "vacq_handle")
                {
                    if (!gm.isEvacuatedGameManager && gm.isFloodedGameManager)
                    {
                        isFlooding = false;
                        isEvacuating = true;
                    }
                    else if (gm.isEvacuatedGameManager && !gm.isFloodedGameManager)
                    {
                        isEvacuating = false;
                        isFlooding = true;
                    }
                }
            }
        }
    }

    // Prüfen, ob das Ablegen von Objekten möglich ist
    if (gm.baseAssemblyPossibleGameManager ||
        gm.lowerPlungerAssemblyPossibleGameManager ||
        gm.patCellLowerCathodeAssemblyPossibleGameManager ||
        gm.patCellSleeveAssemblyPossibleGameManager ||
        gm.patCellUpperCathodeAssemblyPossibleGameManager ||
        gm.patCellUpperPlungerAssemblyPossibleGameManager ||
        gm.gearAssemblyPossibleGameManager ||
        gm.brassTopAssemblyPossibleGameManager)
    {
        isPlacable = true;
    }

    // Platzieren-Input verarbeiten (alle möglichen Assemblierungen in einem Block zusammengefasst)
    if (Input.GetKeyDown(keysBindings.placeItemKey))
    {
        if (gm.baseAssemblyPossibleGameManager)
        {
            assembleBase = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.lowerPlungerAssemblyPossibleGameManager)
        {
            assembleLowerPlunger = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.patCellLowerCathodeAssemblyPossibleGameManager)
        {
            assembleLowerCathode = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.patCellSleeveAssemblyPossibleGameManager)
        {
            assembleSleeve = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.patCellUpperCathodeAssemblyPossibleGameManager)
        {
            assembleUpperCathode = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.patCellUpperPlungerAssemblyPossibleGameManager)
        {
            assembleUpperPlunger = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.gearAssemblyPossibleGameManager)
        {
            assembleGear = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.brassTopAssemblyPossibleGameManager)
        {
            assembleBrassTop = true;
            isPlacable = false;
            DropObject();
        }
        else if (gm.PatCellTesterPlacableGameManager)
        {
            placedPatCallInTester = true;
            DropObject();
        }
    }

    // Glovebox-Exit verarbeiten
    if (isUsingGlovebox && Input.GetKeyDown(keysBindings.exitEquipmentKey))
    {
        isUsingGlovebox = false;
    }

    // Wenn ein Objekt gehalten wird, dieses bewegen/rotieren und ggf. Informationen anzeigen
    if (heldObj != null)
    {
        MoveObject();

        if (Input.GetKey(keysBindings.rotateKey))
        {
            isRotatingObject = true;
            RotateObject();
        }
        else
        {
            heldObjRB.transform.parent = holdArea;
            isRotatingObject = false;
        }

        if (Input.GetKey(keysBindings.informationKey))
        {
            isGettingObjectInformation = true;
            objectInformationText = heldObj.GetComponent<ObjectInformation>().information;
        }
        else
        {
            isGettingObjectInformation = false;
        }
    }
}

/// <summary>
/// Hilfsmethode, um den Outline‑Effekt auf einem Objekt zu aktivieren.
/// Falls noch kein Outline‑Component vorhanden ist, wird dieser hinzugefügt und konfiguriert.
/// </summary>
private void EnableOutline(Transform obj)
{
    Outline outline = obj.GetComponent<Outline>();
    if (outline == null)
    {
        outline = obj.gameObject.AddComponent<Outline>();
        outline.OutlineColor = Color.magenta;
        outline.OutlineWidth = 7.0f;
    }
    outline.enabled = true;
}

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
        if (isUsingGlovebox)
        {
            heldObjectInGloveBox = heldObj;
        }
    }

    void RotateObject()
    {
        heldObjRB.transform.Rotate((mouseY * yRotationMultiplier), (-mouseX * 10), (mouseY * zRotationMultiplier), Space.World);
        //heldObjRB.angularVelocity = Vector3.forward * (-mouseX * 10);
        //heldObjRB.transform.RotateAround(relative, new Vector3((-mouseY * 10), (-mouseX * 10), 0), 0.1f);
    }

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.GetComponent<Rigidbody>().tag != "Player")
        {
            isCarrying = true;
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 30;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        isCarrying = false;
        isRotatingObject = false;
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObjRB.transform.parent = null;
        heldObjRB.AddForce(holdAreaa.GetComponent<HoldArea>().ObjVelocity * 10f, ForceMode.Impulse);
        heldObj = null;
        holdArea.transform.localPosition = new Vector3(0, 0, 0.5f);
        heldObjectInGloveBox = null;
    }

    float Remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
    {
        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }

}
