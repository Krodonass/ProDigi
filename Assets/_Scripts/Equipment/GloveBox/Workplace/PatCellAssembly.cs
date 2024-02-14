using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatCellAssembly : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject baseAssembly;
    public GameObject gearAssembly;
    public GameObject brassTopAssembly;
    public GameObject patCellAssembled;

    public bool bottomAssembled;
    public bool midAssembled;
    public bool topAssembled;

    public bool allAssembled;

    // Update is called once per frame
    void Update()
    {
        if (!bottomAssembled)
        {
            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;
            brassTopAssembly.GetComponent<Collider>().enabled = false;

            baseAssembly.GetComponent<MeshRenderer>().enabled = true;
        }
        if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !bottomAssembled)
        {
            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;
            brassTopAssembly.GetComponent<Collider>().enabled = false;

            baseAssembly.GetComponent<MeshRenderer>().enabled = true;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !midAssembled && bottomAssembled)
        {
            gearAssembly.GetComponent<MeshRenderer>().enabled = true;
            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = true;
            brassTopAssembly.GetComponent<Collider>().enabled = false;

            baseAssembly.GetComponent<MeshRenderer>().enabled = false;
        } else if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && bottomAssembled && midAssembled)
        {
            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;
            baseAssembly.GetComponent<MeshRenderer>().enabled = false;

            brassTopAssembly.GetComponent<MeshRenderer>().enabled = true;
            brassTopAssembly.GetComponent<Collider>().enabled = true;
        } 
        
        if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && bottomAssembled && midAssembled && topAssembled)
        {
            baseAssembly.GetComponent<MeshRenderer>().enabled = false;
            baseAssembly.GetComponent<Collider>().enabled = false;

            gearAssembly.GetComponent<MeshRenderer>().enabled = false;
            gearAssembly.GetComponent<Collider>().enabled = false;


            brassTopAssembly.GetComponent<MeshRenderer>().enabled = false;
            brassTopAssembly.GetComponent<Collider>().enabled = false;
        }

        if (bottomAssembled && midAssembled && topAssembled && !allAssembled)
        {
            Destroy(baseAssembly.GetComponent<Rigidbody>());
            Destroy(gearAssembly.GetComponent<Rigidbody>());
            Destroy(brassTopAssembly.GetComponent<Rigidbody>());

            Destroy(baseAssembly.GetComponent<MeshCollider>());
            Destroy(gearAssembly.GetComponent<MeshCollider>());
            Destroy(brassTopAssembly.GetComponent<MeshCollider>());

            Destroy(baseAssembly.GetComponent<MeshFilter>());
            Destroy(gearAssembly.GetComponent<MeshFilter>());
            Destroy(brassTopAssembly.GetComponent<MeshFilter>());


            allAssembled = true;

            gameObject.SetActive(false);
        }

        if (gameManager.GetComponent<GameManager>().assembleBaseGameManager && !bottomAssembled)
        {
            bottomAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleGearGameManager && !midAssembled)
        {
            midAssembled = true;
        }

        if (gameManager.GetComponent<GameManager>().assembleBrassTopGameManager && !topAssembled)
        {
            topAssembled = true;
        }
    }
}

