using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldArea : MonoBehaviour
{
    public float mouseScroll;

    // Update is called once per frame
    void Update()
    {
        mouseScroll = Input.mouseScrollDelta.y;
        if (mouseScroll > 0f && transform.localPosition.z < 3f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.01f);
        } else if (mouseScroll < 0f && transform.localPosition.z > 1f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.01f);
        }
    }
}
