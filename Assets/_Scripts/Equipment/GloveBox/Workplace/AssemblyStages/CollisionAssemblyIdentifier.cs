using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAssemblyIdentifier : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject baseAssembly;
    public GameObject gearAssembly;
    public GameObject brassTopAssembly;

    public bool baseAssemblyPossible;
    public bool baseAssembled;

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
            gameObject.transform.tag = null;
        }
        if (gameObject.name == "gear" && gameManager.GetComponent<GameManager>().assembleGearGameManager)
        {
            gameObject.transform.position = gearAssembly.transform.position;
            gameObject.transform.rotation = gearAssembly.transform.rotation;
            gameObject.transform.tag = null;
        }
        if (gameObject.name == "brass_top" && gameManager.GetComponent<GameManager>().assembleBrassTopGameManager)
        {
            gameObject.transform.position = brassTopAssembly.transform.position;
            gameObject.transform.rotation = brassTopAssembly.transform.rotation;
            gameObject.transform.tag = null;
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if (gameObject.name == "base" && collision.gameObject.name == "BaseAssembly")
        {
            baseAssemblyPossible = true;
        }

        if (gameObject.name == "gear" && collision.gameObject.name == "GearAssembly")
        {
            gearAssemblyPossible = true;
        }

        if (gameObject.name == "brass_top" && collision.gameObject.name == "BrassTopAssembly")
        {
            brasstopAssemblyPossible = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (gameObject.name == "base" && collision.gameObject.name == "BaseAssembly")
        {
            baseAssemblyPossible = false;
        }

        if (gameObject.name == "gear" && collision.gameObject.name == "GearAssembly")
        {
            gearAssemblyPossible = false;
        }

        if (gameObject.name == "brass_top" && collision.gameObject.name == "BrassTopAssembly")
        {
            brasstopAssemblyPossible = false;
        }
    }
}
