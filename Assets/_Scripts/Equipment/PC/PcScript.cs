using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{

    public Transform PlayerPCPostion;

    private MeshCollider meshCollider;


    

    // Start is called before the first frame update
    void Start()
    {
        PickupController.PCStartEvent += OnEnter;
        PcCanvas.PCQuitEvent += OnExit;

        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnExit(){
        if(meshCollider){
            meshCollider.enabled = true;
        }
    }

//Disables Mesh collider so the collider dont block the ui
    public void OnEnter(Transform transform){
        if(meshCollider){
            meshCollider.enabled = false;
        }
    }


}
