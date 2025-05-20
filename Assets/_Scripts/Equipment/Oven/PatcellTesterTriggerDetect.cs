using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PatcellTesterTriggerDetect : MonoBehaviour
{
    
    public GameObject gameManager;
    public GameObject Trigger;
    public GameObject PatCellAssembled;
    public GameObject PatCellInTester;

    public bool placingPossible;

    public Material assemblyPossible;
    public Material assemblyNotPossible;
    
    
    void Update()
    {
        //Debug.Log(gameManager.GetComponent<GameManager>().placedPatcellInTesterGameManager);

        if (gameManager.GetComponent<GameManager>().placedPatcellInTesterGameManager)
        {
  
            PatCellInTester.SetActive(true);
            PatCellAssembled.SetActive(false);
            Trigger.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.name == "PatCellAssembled")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            placingPossible = true;
            Trigger.GetComponent<Renderer>().material = assemblyPossible;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        placingPossible = false;
        Trigger.GetComponent<Renderer>().material = assemblyNotPossible;
    }
}
