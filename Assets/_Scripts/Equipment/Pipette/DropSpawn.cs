using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject keybindings;
    public GameObject drop;
    public Transform dropSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameManager.GetComponent<GameManager>().isCarryingPipetteGameManager && Input.GetKeyDown(keybindings.GetComponent<KeysBindings>().placeItemKey))
        {
            Debug.Log("Spawn");
            GameObject g = Instantiate(drop, new Vector3(dropSpawn.transform.position.x, dropSpawn.transform.position.y, dropSpawn.transform.position.z), Quaternion.identity);
        }
    }
}
