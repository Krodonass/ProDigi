using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject gameManger;
    public MeshRenderer m;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer m = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger.GetComponent<GameManager>().isUsingGloveboxGameManager)
        {
            m.enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        } else
        {
            m.enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
