using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLaserPointer : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject DropSpawn;
    public GameObject LaserPointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserPointer.transform.position = new Vector3(DropSpawn.transform.position.x, DropSpawn.transform.position.y - 1f, DropSpawn.transform.position.z);

        if (gameManager.GetComponent<GameManager>().activateLaserPointerGameManager)
        {
            LaserPointer.GetComponent<MeshRenderer>().enabled = true;
        } else
        {
            LaserPointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
