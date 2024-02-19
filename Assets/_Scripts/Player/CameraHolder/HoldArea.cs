using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldArea : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject playerCam;
    private float mouseScroll;
    Vector3 PrevPos;
    Vector3 NewPos;
    public Vector3 ObjVelocity;
    private void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }
    // Update is called once per framessssss
    void Update()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation

        mouseScroll = Input.mouseScrollDelta.y;
        if (mouseScroll > 0f && transform.localPosition.z < 1f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.01f);
        } else if (mouseScroll < 0f && transform.localPosition.z > 0.1f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.01f);
        }
    }
}
