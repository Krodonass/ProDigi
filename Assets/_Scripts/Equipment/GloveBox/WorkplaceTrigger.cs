using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkplaceTrigger : MonoBehaviour
{
    public GameObject gameManager;

    public bool baseInWorkplace;
    public bool lowerPlungerInWorkplace;
    public bool lowerCathodeInWorkplace;
    public bool sleeveInWorkplace;
    public bool upperCathodeInWorkplace;
    public bool upperPlungerInWorkplace;
    public bool gearInWorkplace;
    public bool brassTopInWorkplace;

    public bool allComponentsInWorkplace;
    public bool assembledPatCellInWorkplace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (baseInWorkplace && lowerPlungerInWorkplace && lowerCathodeInWorkplace && sleeveInWorkplace && upperCathodeInWorkplace && upperPlungerInWorkplace && gearInWorkplace && brassTopInWorkplace)
        {
            allComponentsInWorkplace = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "base")
        {
            baseInWorkplace = true;
        }
        if (collision.gameObject.name == "lower_plunger")
        {
            lowerPlungerInWorkplace = true;
        }
        if (collision.gameObject.name == "positive_lower_cathode")
        {
            lowerCathodeInWorkplace = true;
        }
        if (collision.gameObject.name == "sleeve")
        {
            sleeveInWorkplace = true;
        }
        if (collision.gameObject.name == "negative_upper_cathode")
        {
            upperCathodeInWorkplace = true;
        }
        if (collision.gameObject.name == "upper_plunger")
        {
            upperPlungerInWorkplace = true;
        }
        if (collision.gameObject.name == "gear")
        {
            gearInWorkplace = true;
        }
        if (collision.gameObject.name == "brass_top")
        {
            brassTopInWorkplace = true;
        }

        if (collision.gameObject.name == "PatCellAssembled")
        {
            assembledPatCellInWorkplace = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "base")
        {
            baseInWorkplace = false;
        }
        if (collision.gameObject.name == "lower_plunger")
        {
            lowerPlungerInWorkplace = false;
        }
        if (collision.gameObject.name == "positive_lower_cathode")
        {
            lowerCathodeInWorkplace = false;
        }
        if (collision.gameObject.name == "sleeve")
        {
            sleeveInWorkplace = false;
        }
        if (collision.gameObject.name == "negative_upper_cathode")
        {
            upperCathodeInWorkplace = false;
        }
        if (collision.gameObject.name == "upper_plunger")
        {
            upperPlungerInWorkplace = false;
        }
        if (collision.gameObject.name == "gear")
        {
            gearInWorkplace = false;
        }
        if (collision.gameObject.name == "brass_top")
        {
            brassTopInWorkplace = false;
        }

        if (collision.gameObject.name == "PatCellAssembled")
        {
            assembledPatCellInWorkplace = false;
        }
    }
}
