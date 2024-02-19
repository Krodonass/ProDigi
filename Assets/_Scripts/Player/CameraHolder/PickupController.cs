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
    public bool assembleGear;
    public bool assembleBrassTop;

    public bool isOpeningOutterHatch;
    public bool isClosingOutterHatch;

    public bool isOpeningInnerHatch;
    public bool isClosingInnerHatch;

    public bool isOpeningOvenDoor;
    public bool isClosingOvenDoor;


    public bool isRotatingObject = false;
    public bool isGettingObjectInformation = false;
    public string objectInformationText = "";

    public float yRotationMultiplier;
    public float zRotationMultiplier;
    public float z2;

    private void Update() 
    {
        relative = transform.InverseTransformDirection(Vector3.forward);

        mouseX = Input.GetAxis("Mouse X") * sensX;
        mouseY = Input.GetAxis("Mouse Y") * sensY;

        Debug.Log(gameObject.transform.rotation.eulerAngles.y);


        if (gameObject.transform.rotation.eulerAngles.y <= 180)
        {
            yRotationMultiplier = Remap(gameObject.transform.rotation.eulerAngles.y, 0, 180, 10, -10);
        } else if (gameObject.transform.rotation.eulerAngles.y > 180)
        {
            yRotationMultiplier = Remap(gameObject.transform.rotation.eulerAngles.y, 180, 360, -10, 10);
        }

        if (gameObject.transform.rotation.eulerAngles.y > 90 && gameObject.transform.rotation.eulerAngles.y <= 270)
        {
            zRotationMultiplier = Remap(gameObject.transform.rotation.eulerAngles.y, 90, 270, -10, 10);
        }

        if (gameObject.transform.rotation.eulerAngles.y < 90)
        {
            zRotationMultiplier = Remap(gameObject.transform.rotation.eulerAngles.y, 90, 0, -10, 0);
        } else if (gameObject.transform.rotation.eulerAngles.y > 270 && gameObject.transform.rotation.eulerAngles.y <= 360)
        {
            zRotationMultiplier = Remap(gameObject.transform.rotation.eulerAngles.y, 270, 360, 10, 0);
        }

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange) && raycastHit.transform.CompareTag("Pickupable") && !isCarrying && !isUsable)
        {
            highlight = raycastHit.transform;
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                isPickupable = true;
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            } else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange) && raycastHit.transform.CompareTag("Usable") && !isCarrying)
        {
            highlight = raycastHit.transform;
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                isUsable = true;
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            } else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        } else {
            isUsable = false;
            isPickupable = false;
            highlight = null;
        } 


        if (Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().grabKey))
        {
            if (heldObj == null) // No Object in Hand
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange))
                {
                    PickupObject(raycastHit.transform.gameObject);
                }
                //isCarrying = false;
            } else
            {
                DropObject();
            }
            if (heldObj == null && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, pickupRange))
            {
                if (raycastHit.collider.name == "glass")
                {
                    isUsingGlovebox = true;
                }

                if (isUsable && raycastHit.collider.name == "OutterHatch") 
                { 
                   if (!gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager)
                   {
                        isOpeningOutterHatch = true;
                        isClosingOutterHatch = false;
                   } else
                   {
                        isClosingOutterHatch = true;
                        isOpeningOutterHatch = false;
                   }
                }

                if (isUsable && raycastHit.collider.name == "InnerHatch")
                {
                    if (!gameManager.GetComponent<GameManager>().isOpenInnerHatchGameManager)
                    {
                        isOpeningInnerHatch = true;
                        isClosingInnerHatch = false;
                    } else
                    {
                        isClosingInnerHatch = true;
                        isOpeningInnerHatch = false;
                    }
                }

                if (isUsable && raycastHit.collider.name == "OvenDoor")
                {
                    if (!gameManager.GetComponent<GameManager>().isOpenOvenDoorGameManager)
                    {
                        isOpeningOvenDoor = true;
                        isClosingOvenDoor = false;
                    } else
                    {
                        isClosingOvenDoor = true;
                        isOpeningOvenDoor = false;
                    }
                }
            }
        }
        
        if (gameManager.GetComponent<GameManager>().baseAssemblyPossibleGameManager || 
            gameManager.GetComponent<GameManager>().gearAssemblyPossibleGameManager ||
            gameManager.GetComponent<GameManager>().brassTopAssemblyPossibleGameManager)
        {
            isPlacable = true;
        }

        if (Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().placeItemKey) && gameManager.GetComponent<GameManager>().baseAssemblyPossibleGameManager)
        {
            assembleBase = true;
            isPlacable = false;
            DropObject();
        }

        if (Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().placeItemKey) && gameManager.GetComponent<GameManager>().gearAssemblyPossibleGameManager)
        {
            assembleGear = true;
            isPlacable = false;
            DropObject();
        }

        if (Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().placeItemKey) && gameManager.GetComponent<GameManager>().brassTopAssemblyPossibleGameManager)
        {
            assembleBrassTop = true;
            isPlacable = false;
            DropObject();
        }

        if (isUsingGlovebox && Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().exitEquipmentKey))
        {
            isUsingGlovebox = false;
        }

        if (heldObj != null)
        {
            MoveObject();
            if (Input.GetKey(keybindings.GetComponent<KeysBindings>().rotateKey))
            {
                isRotatingObject = true;
                RotateObject();
            } else
            {
                heldObjRB.transform.parent = holdArea;
                isRotatingObject = false;
            }
            if (Input.GetKey(keybindings.GetComponent<KeysBindings>().informationKey))
            {
                isGettingObjectInformation = true;
                objectInformationText = heldObj.GetComponent<ObjectInformation>().information;
            } else
            {
                isGettingObjectInformation = false;
            }
        }
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
