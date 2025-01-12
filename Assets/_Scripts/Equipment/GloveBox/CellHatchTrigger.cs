using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHatchTrigger : MonoBehaviour
{
    public GameObject gameManager;

    public bool baseInHatch;
    public bool lowerPlungerInHatch;
    public bool lowerCathodeInHatch;
    public bool sleeveInHatch;
    public bool upperCathodeInHatch;
    public bool upperPlungerInHatch;
    public bool gearInHatch;
    public bool brassTopInHatch;

    public bool allComponentsInHatch;

    public bool assembledPatCellInHatch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (baseInHatch && lowerPlungerInHatch && lowerCathodeInHatch && sleeveInHatch && upperCathodeInHatch && upperPlungerInHatch && gearInHatch && brassTopInHatch)
        {
            allComponentsInHatch = true;
        } else
        {
            allComponentsInHatch = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "base")
        {
            baseInHatch = true;
        }
        if (collision.gameObject.name == "lower_plunger")
        {
            lowerPlungerInHatch = true;
        }
        if (collision.gameObject.name == "positive_lower_cathode")
        {
            lowerCathodeInHatch = true;
        }
        if (collision.gameObject.name == "sleeve")
        {
            sleeveInHatch = true;
        }
        if (collision.gameObject.name == "negative_upper_cathode")
        {
            upperCathodeInHatch = true;
        }
        if (collision.gameObject.name == "upper_plunger")
        {
            upperPlungerInHatch = true;
        }
        if (collision.gameObject.name == "gear")
        {
            gearInHatch = true;
        }
        if (collision.gameObject.name == "brass_top")
        {
            brassTopInHatch = true;
        }

        if (collision.gameObject.name == "PatCellAssembled")
        {
            assembledPatCellInHatch = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "base")
        {
            baseInHatch = false;
        }
        if (collision.gameObject.name == "lower_plunger")
        {
            lowerPlungerInHatch = false;
        }
        if (collision.gameObject.name == "positive_lower_cathode")
        {
            lowerCathodeInHatch = false;
        }
        if (collision.gameObject.name == "sleeve")
        {
            sleeveInHatch = false;
        }
        if (collision.gameObject.name == "negative_upper_cathode")
        {
            upperCathodeInHatch = false;
        }
        if (collision.gameObject.name == "upper_plunger")
        {
            upperPlungerInHatch = false;
        }
        if (collision.gameObject.name == "gear")
        {
            gearInHatch = false;
        }
        if (collision.gameObject.name == "brass_top")
        {
            brassTopInHatch = false;
        }

        if (collision.gameObject.name == "PatCellAssembled")
        {
            assembledPatCellInHatch = false;
        }
    }
}
