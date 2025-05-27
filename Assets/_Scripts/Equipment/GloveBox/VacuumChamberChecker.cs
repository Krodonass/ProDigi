using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumChamberChecker : MonoBehaviour
{
    public GameObject[] batteryParts;

    public int batteryPartsCount;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == batteryParts[0] || col.gameObject == batteryParts[1] || col.gameObject == batteryParts[2] || col.gameObject == batteryParts[3] 
            || col.gameObject == batteryParts[4] || col.gameObject == batteryParts[5] || col.gameObject == batteryParts[6] || col.gameObject == batteryParts[7]
            || col.gameObject == batteryParts[8] )
        {
            Debug.Log("Batterieteil in Vakuumkammer gepackt!");
            batteryPartsCount++;
        }
    }
    
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject == batteryParts[0] || col.gameObject == batteryParts[1] || col.gameObject == batteryParts[2] || col.gameObject == batteryParts[3] 
            || col.gameObject == batteryParts[4] || col.gameObject == batteryParts[5] || col.gameObject == batteryParts[6] || col.gameObject == batteryParts[7]
            || col.gameObject == batteryParts[8] )
        {
            Debug.Log("Batterieteil aus Vakuumkammer rausgenommen!");
            batteryPartsCount--;
        }
    }
    
}
