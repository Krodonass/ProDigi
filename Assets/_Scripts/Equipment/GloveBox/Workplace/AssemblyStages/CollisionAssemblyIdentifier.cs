using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAssemblyIdentifier : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject baseAssembly;
    public GameObject lowerPlungerAssembly;
    public GameObject lowerCathodeAssembly;
    public GameObject sleeveAssembly;
    public GameObject electrolyteAssembly;
    public GameObject UpperCathodeAssembly;
    public GameObject upperPlungerAssembly;
    public GameObject gearAssembly;
    public GameObject brassTopAssembly;

    public Material assemblyPossible;
    public Material assemblyNotPossible;

    public bool baseAssemblyPossible;
    public bool baseAssembled;

    public bool lowerPlungerAssemblyPossible;
    public bool lowerPlungerAssembled;

    public bool lowerCathodeAssemblyPossible;
    public bool lowerCathodeAssembled;

    public bool sleeveAssemblyPossible;
    public bool sleeveAssembled;

    public bool electrolyteAssemblyPossible;
    public bool electrolyteAssembled;

    public bool upperCathodeAssemblyPossible;
    public bool upperCathodeAssembled;

    public bool upperPlungerAssemblyPossible;
    public bool upperPlungerAssembled;

    public bool gearAssemblyPossible;
    public bool gearAssembled;

    public bool brasstopAssemblyPossible;
    public bool brasstopAssembled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name == "base" && gameManager.GetComponent<GameManager>().assembleBaseGameManager)
        {
            gameObject.transform.position = baseAssembly.transform.position;
            gameObject.transform.rotation = baseAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "lower_plunger" && gameManager.GetComponent<GameManager>().assembleLowerPlungerGameManager)
        {
            gameObject.transform.position = lowerPlungerAssembly.transform.position;
            gameObject.transform.rotation = lowerPlungerAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "positive_lower_cathode" && gameManager.GetComponent<GameManager>().assembleLowerCathodeGameManager)
        {
            
            gameObject.transform.position = lowerCathodeAssembly.transform.position;
            gameObject.transform.rotation = lowerCathodeAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "sleeve" && gameManager.GetComponent<GameManager>().assembleSleeveGameManager)
        {
            gameObject.transform.position = sleeveAssembly.transform.position;
            gameObject.transform.rotation = sleeveAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "electrolyte" && gameManager.GetComponent<GameManager>().assembleElectrolyteGameManager)
        {
            gameObject.transform.position = sleeveAssembly.transform.position;
            gameObject.transform.rotation = sleeveAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "negative_upper_cathode" && gameManager.GetComponent<GameManager>().assembleUpperCathodeGameManager)
        {
            gameObject.transform.position = UpperCathodeAssembly.transform.position;
            gameObject.transform.rotation = UpperCathodeAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "upper_plunger" && gameManager.GetComponent<GameManager>().assembleUpperPlungerGameManager)
        {
            gameObject.transform.position = upperPlungerAssembly.transform.position;
            gameObject.transform.rotation = upperPlungerAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "gear" && gameManager.GetComponent<GameManager>().assembleGearGameManager)
        {
            gameObject.transform.position = gearAssembly.transform.position;
            gameObject.transform.rotation = gearAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }
        if (gameObject.name == "brass_top" && gameManager.GetComponent<GameManager>().assembleBrassTopGameManager)
        {
            gameObject.transform.position = brassTopAssembly.transform.position;
            gameObject.transform.rotation = brassTopAssembly.transform.rotation;
            gameObject.transform.tag = "Untagged";
        }

        if (gameManager.GetComponent<GameManager>().allAssembledGameManager)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if (gameObject.name == "base" && collision.gameObject.name == "BaseAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            baseAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "lower_plunger" && collision.gameObject.name == "LowerPlungerAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            lowerPlungerAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "positive_lower_cathode" && collision.gameObject.name == "LowerCathodeAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            lowerCathodeAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "sleeve" && collision.gameObject.name == "SleeveAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            sleeveAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }
        
        if (gameObject.name == "PipetteLaserPointer" && collision.gameObject.name == "ElectrolyteAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            Debug.Log("pipi");
            Debug.Log("electro");
            electrolyteAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "negative_upper_cathode" && collision.gameObject.name == "UpperCathodeAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            Debug.Log("hui");
            upperCathodeAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "upper_plunger" && collision.gameObject.name == "UpperPlungerAssembly")
        {
            // Zum Spieler kippen
            // "Y"- Rotation
            upperPlungerAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;

        }

        if (gameObject.name == "gear" && collision.gameObject.name == "GearAssembly")
        {
            gearAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;
        }

        if (gameObject.name == "brass_top" && collision.gameObject.name == "BrassTopAssembly")
        {
            brasstopAssemblyPossible = true;
            collision.gameObject.GetComponent<Renderer>().material = assemblyPossible;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.name == "PipetteLaserPointer")
        {
            
        }

        if (collision.gameObject.tag == "ground")
        {
            FindAnyObjectByType<AudioManager>().Play("Small_Collision");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (gameObject.name == "base" && collision.gameObject.name == "BaseAssembly")
        {
            baseAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "lower_plunger" && collision.gameObject.name == "LowerPlungerAssembly")
        {
            lowerPlungerAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "positive_lower_cathode" && collision.gameObject.name == "LowerCathodeAssembly")
        {
            lowerCathodeAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "sleeve" && collision.gameObject.name == "SleeveAssembly")
        {
            sleeveAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "PipetteLaserPointer" && collision.gameObject.name == "ElectrolyteAssembly")
        {
            electrolyteAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "negative_upper_cathode" && collision.gameObject.name == "UpperCathodeAssembly")
        {
            upperCathodeAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "upper_plunger" && collision.gameObject.name == "UpperPlungerAssembly")
        {
            upperPlungerAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "gear" && collision.gameObject.name == "GearAssembly")
        {
            gearAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }

        if (gameObject.name == "brass_top" && collision.gameObject.name == "BrassTopAssembly")
        {
            brasstopAssemblyPossible = false;
            collision.gameObject.GetComponent<Renderer>().material = assemblyNotPossible;
        }
    }
}
