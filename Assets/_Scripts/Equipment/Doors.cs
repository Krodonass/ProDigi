using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OpenDiretionTypes
{
    Left,
    Right,
}


public enum Axis
{
    X,
    Y,
    Z,
}

public class Doors : MonoBehaviour
{

    public event Action<Boolean> OnOpenDoor;
    
    //----------------Needs Door Tag!!!!------------------------------
    public GameObject gameManager;

    public OpenDiretionTypes OpenDiretion;

    public Axis Axis = Axis.Y;
    
    //Wie schnell die Animation abgespielt wird
    public float toggleTime = .5f;

    //Der Winkel in dem die tür geöffnet werden soll, oder wie weit die Schublade geöffnet werden kann
    public float openAngle = 90;

    private float closedAngle = 0;
    
    [HideInInspector]
    public string isLDopen = "n";
    [HideInInspector]
    public string isTDopen = "n";

    [HideInInspector] 
    public Boolean isOpen = false;

    [HideInInspector] 
    public Boolean isAnimating = false;
    
    private Coroutine _currentCoroutine;

    private bool canOpen = true;
    
    public Drawer DrawerThatIsInWay;

    void Start()
    {
        if (DrawerThatIsInWay)
        {
            DrawerThatIsInWay.OnUse += ToggleCanOpen;
        }
    }

    //Opens or close the door
    public virtual void InvokeInteraction()
    {
        if (CompareTag("Door"))
        {
            if (canOpen)
            {
                StartCoroutine(RotateDoor());
            }
            return;
        }
        
         if (gameObject.name == "mobile_cabinet_door_01" || gameObject.name == "OvenDoor")
        {
            Debug.Log("lelelel");
            if (isLDopen == "n")
            {
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 1, 0);
                isLDopen = "o";
                StartCoroutine(stopDoor());
            } else if (isLDopen == "y")
            {
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0, -1, 0);
                isLDopen = "c";
                StartCoroutine(stopDoor());
            }
        }

        if (gameObject.name == "OutterHatch")
        {
            if (isLDopen == "n")
            {
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 2);
                isLDopen = "o";
                StartCoroutine(stopDoor());
            }
            else if (isLDopen == "y")
            {
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -2);
                isLDopen = "c";
                StartCoroutine(stopDoor());
            }
        }

        if (gameObject.name == "mobile_cabinet_drawer_01" || gameObject.name == "benching_drawer_01" || gameObject.name == "benching_drawer_02" || gameObject.name == "benching_drawer_03" || gameObject.name == "benching_drawer_04" || gameObject.name == "benching_drawer_05")
        {
            Debug.Log("lelelel");
            if (isTDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
                isTDopen = "o";
                StartCoroutine(stopDrawer());
            } else if (isTDopen == "y") {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
                isTDopen = "c";
                StartCoroutine(stopDrawer());
            }
        }

        if (gameObject.name == "oven_tray")
        {
            Debug.Log("lelelel");
            if (isTDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
                isTDopen = "o";
                StartCoroutine(stopDrawer());
            }
            else if (isTDopen == "y")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
                isTDopen = "c";
                StartCoroutine(stopDrawer());
            }
        }

        if (gameObject.name == "vacq_tray" && !gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager)
        {
            if (isTDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
                isTDopen = "o";
                StartCoroutine(stopDrawer());
            }
            else if (isTDopen == "y")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
                isTDopen = "c";
                StartCoroutine(stopDrawer());
            }
        }
        else if (gameObject.name == "vacq_tray" && gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager)
        {
            Debug.Log("lelelel");
            if (isTDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
                isTDopen = "o";
                StartCoroutine(stopDrawer());
            }
            else if (isTDopen == "y")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
                isTDopen = "c";
                StartCoroutine(stopDrawer());
            }
        }
    }

    // Coroutine: rotiert das GameObject von startAngle zu targetAngle
    private IEnumerator RotateDoor()
    {
        if (isAnimating)
            yield break;

        isAnimating = true;

        int axisIndex = (int)Axis;
        float timeElapsed = 0f;

        // aktuellen Startwinkel auf der gewählten Achse holen
        float startAngle = transform.localEulerAngles[axisIndex];

        // Zielwinkel bestimmen
        float targetAngle = isOpen ? closedAngle : openAngle;
        targetAngle = (OpenDiretion == OpenDiretionTypes.Left) ? targetAngle : -targetAngle;

        // Unitys Euler-Werte normalisieren (0–360)
        if (targetAngle - startAngle > 180f) startAngle += 360f;
        if (startAngle - targetAngle > 180f) targetAngle += 360f;

        // sanftes Interpolieren
        while (timeElapsed < toggleTime)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / toggleTime);
            float currentAngle = Mathf.Lerp(startAngle, targetAngle, t);

            Vector3 rotation = transform.localEulerAngles;
            rotation[axisIndex] = currentAngle;
            transform.localEulerAngles = rotation;

            yield return null;
        }

        // Endrotation exakt setzen und wieder in 0–360 umwandeln
        Vector3 finalRot = transform.localEulerAngles;
        finalRot[axisIndex] = targetAngle % 360f;
        transform.localEulerAngles = finalRot;

        isOpen = !isOpen;
        if (OnOpenDoor != null)
        {
            OnOpenDoor.Invoke(isOpen);
        }
        isAnimating = false;
    }

    IEnumerator stopDoor()
    {
        yield return new WaitForSeconds(4);

        if (isLDopen == "o")
        {
            isLDopen = "y";
        }

        if (isLDopen == "c")
        {
            isLDopen = "n";
        }
    }

    IEnumerator stopDrawer()
    {
        Debug.Log("lol");
        yield return new WaitForSeconds(4);

        if (isTDopen == "o")
        {
            isTDopen = "y";
        }

        if (isTDopen == "c")
        {
            isTDopen = "n";
        }
    }

    private void ToggleCanOpen()
    {
        canOpen = !canOpen;
    }
}
