using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject gameManager;
    
    [HideInInspector]
    public string isLDopen = "n";
    [HideInInspector]
    public string isTDopen = "n";
    
    //Opens or close the door
    public void InvokeInteraction()
    {
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
}
