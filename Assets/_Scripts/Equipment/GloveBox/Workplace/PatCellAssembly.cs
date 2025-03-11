using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatCellAssembly : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject baseAssembly;
    public GameObject lowerPlungerAssembly;
    public GameObject lowerCathodeAssembly;
    public GameObject sleeveAssembly;
    public GameObject electrolyteAssembly;
    public GameObject upperCathodeAssembly;
    public GameObject upperPlungerAssembly;
    public GameObject gearAssembly;
    public GameObject brassTopAssembly;
    public GameObject patCellAssembled;

    public bool baseAssembled;
    public bool lowerPlungerAssembled;
    public bool lowerCathodeAssembled;
    public bool sleeveAssembled;
    public bool electrolyteAssembled;
    public bool upperCathodeAssembled;
    public bool upperPlungerAssembled;
    public bool gearAssembled;
    public bool brassTopAssembled;

    public bool allAssembled;

    // Update is called once per frame
    void Update()
    {
        if (!baseAssembled)
        {
            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            upperPlungerAssembly.GetComponent<MeshRenderer>().enabled = false;
            upperCathodeAssembly.GetComponent<MeshRenderer>().enabled = false;
            sleeveAssembly.GetComponent<MeshRenderer>().enabled = false;
            electrolyteAssembly.GetComponent<MeshRenderer>().enabled = false;
            lowerCathodeAssembly.GetComponent<MeshRenderer>().enabled = false;
            lowerPlungerAssembly.GetComponent<MeshRenderer>().enabled = false;



            brassTopAssembly.GetComponent<Collider>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;
            upperPlungerAssembly.GetComponent<Collider>().enabled = false;
            upperCathodeAssembly.GetComponent<Collider>().enabled = false;
            sleeveAssembly.GetComponent<Collider>().enabled = false;
            electrolyteAssembly.GetComponent<Collider>().enabled = false;
            lowerCathodeAssembly.GetComponent<Collider>().enabled = false;
            lowerPlungerAssembly.GetComponent<Collider>().enabled = false;


            baseAssembly.GetComponent<MeshRenderer>().enabled = true;
        }
        if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !baseAssembled)
        {
            baseAssembly.GetComponent<MeshRenderer>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !lowerPlungerAssembled && baseAssembled)
        {
            baseAssembly.GetComponent<Collider>().enabled = false;
            baseAssembly.GetComponent<MeshRenderer>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellBase.GetComponent<Collider>().enabled = false;

            lowerPlungerAssembly.GetComponent<MeshRenderer>().enabled = true;
            lowerPlungerAssembly.GetComponent<Collider>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager &&  lowerPlungerAssembled && !lowerCathodeAssembled)
        {
            lowerPlungerAssembly.GetComponent<MeshRenderer>().enabled = false;
            lowerPlungerAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellLowerPlunger.GetComponent<Collider>().enabled = false;

            lowerCathodeAssembly.GetComponent<MeshRenderer>().enabled = true;
            lowerCathodeAssembly.GetComponent<Collider>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && lowerCathodeAssembled && !sleeveAssembled)
        {
            lowerCathodeAssembly.GetComponent<MeshRenderer>().enabled = false;
            lowerCathodeAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellLowerCathode.GetComponent<Collider>().enabled = false;

            sleeveAssembly.GetComponent<MeshRenderer>().enabled = true;
            sleeveAssembly.GetComponent<Collider>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && sleeveAssembled && !electrolyteAssembled)
        {
            sleeveAssembly.GetComponent<MeshRenderer>().enabled = false;
            sleeveAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellSleeve.GetComponent<Collider>().enabled = false;

            electrolyteAssembly.GetComponent<MeshRenderer>().enabled = true;
            electrolyteAssembly.GetComponent<Collider>().enabled = true;
        }
        else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && electrolyteAssembled && !upperCathodeAssembled)
        {
            electrolyteAssembly.GetComponent<MeshRenderer>().enabled = false;
            electrolyteAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellElectrolyte.GetComponent<Collider>().enabled = false;

            upperCathodeAssembly.GetComponent<MeshRenderer>().enabled = true;
            upperCathodeAssembly.GetComponent<Collider>().enabled = true;
        }
        else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && upperCathodeAssembled && !upperPlungerAssembled)
        {
            upperCathodeAssembly.GetComponent<MeshRenderer>().enabled = false;
            upperCathodeAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellUpperCathode.GetComponent<Collider>().enabled = false;

            upperPlungerAssembly.GetComponent<MeshRenderer>().enabled = true;
            upperPlungerAssembly.GetComponent<Collider>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && upperPlungerAssembled && !gearAssembled)
        {
            upperPlungerAssembly.GetComponent<MeshRenderer>().enabled = false;
            upperPlungerAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellUpperPlunger.GetComponent<Collider>().enabled = false;

            gearAssembly.GetComponent<MeshRenderer>().enabled = true;
            gearAssembly.GetComponent<Collider>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && gearAssembled && !brassTopAssembled)
        {
            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;
            gameManager.GetComponent<GameManager>().patCellGear.GetComponent<Collider>().enabled = false;

            brassTopAssembly.GetComponent<MeshRenderer>().enabled = true;
            brassTopAssembly.GetComponent<Collider>().enabled = true;
        }

        if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && baseAssembled && gearAssembled && brassTopAssembled)
        {
            baseAssembly.GetComponent<MeshRenderer>().enabled = false;
            baseAssembly.GetComponent<Collider>().enabled = false;

            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;


            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            brassTopAssembly.GetComponent<Collider>().enabled = false;
        }

        if (baseAssembled && lowerPlungerAssembled && lowerCathodeAssembled && sleeveAssembled && upperCathodeAssembled && upperPlungerAssembled && gearAssembled && brassTopAssembled && !allAssembled)
        {
            Destroy(baseAssembly.GetComponent<Rigidbody>());
            Destroy(lowerPlungerAssembly.GetComponent<Rigidbody>());
            Destroy(lowerCathodeAssembly.GetComponent<Rigidbody>());
            Destroy(sleeveAssembly.GetComponent<Rigidbody>());
            Destroy(upperCathodeAssembly.GetComponent<Rigidbody>());
            Destroy(upperPlungerAssembly.GetComponent<Rigidbody>());
            Destroy(gearAssembly.GetComponent<Rigidbody>());
            Destroy(brassTopAssembly.GetComponent<Rigidbody>());

            Destroy(baseAssembly.GetComponent<Collider>());
            Destroy(lowerPlungerAssembly.GetComponent<Collider>());
            Destroy(lowerCathodeAssembly.GetComponent<Collider>());
            Destroy(sleeveAssembly.GetComponent<Collider>());
            Destroy(upperCathodeAssembly.GetComponent<Collider>());
            Destroy(upperPlungerAssembly.GetComponent<Collider>());
            Destroy(gearAssembly.GetComponent<Collider>());
            Destroy(brassTopAssembly.GetComponent<Collider>());

            Destroy(baseAssembly.GetComponent<MeshFilter>());
            Destroy(lowerPlungerAssembly.GetComponent<MeshFilter>());
            Destroy(lowerCathodeAssembly.GetComponent<MeshFilter>());
            Destroy(sleeveAssembly.GetComponent<MeshFilter>());
            Destroy(upperCathodeAssembly.GetComponent<MeshFilter>());
            Destroy(upperPlungerAssembly.GetComponent<MeshFilter>());
            Destroy(gearAssembly.GetComponent<MeshFilter>());
            Destroy(brassTopAssembly.GetComponent<MeshFilter>());


            allAssembled = true;

            gameObject.SetActive(false);
        }

        if (gameManager.GetComponent<GameManager>().assembleBaseGameManager && !baseAssembled)
        {
            baseAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleLowerPlungerGameManager && !lowerPlungerAssembled)
        {
            lowerPlungerAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleLowerCathodeGameManager && !lowerCathodeAssembled)
        {
            lowerCathodeAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleSleeveGameManager && !sleeveAssembled)
        {
            sleeveAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleUpperCathodeGameManager && !upperCathodeAssembled)
        {
            upperCathodeAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleUpperCathodeGameManager && !upperCathodeAssembled)
        {
            upperCathodeAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleUpperPlungerGameManager && !upperPlungerAssembled)
        {
            upperPlungerAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleGearGameManager && !gearAssembled)
        {
            gearAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleBrassTopGameManager && !brassTopAssembled)
        {
            brassTopAssembled = true;
        }
    }
}

