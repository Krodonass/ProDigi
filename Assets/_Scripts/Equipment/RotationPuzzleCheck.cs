using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzleCheck : MonoBehaviour
{
    public float xValueStart;
    public float xValueEnd;

    public float yValueStart;
    public float yValueEnd;

    public float zValueStart;
    public float zValueEnd;

    public bool xValueAccepted;
    public bool yValueAccepted;
    public bool zValueAccepted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.x >= xValueStart && transform.eulerAngles.x <= xValueEnd)
        {
            xValueAccepted = true;
        } else
        {
            xValueAccepted = false;
        }

        if (transform.eulerAngles.y >= xValueStart && transform.eulerAngles.y <= xValueEnd)
        {
            yValueAccepted = true;
        } else
        {
            yValueAccepted = false;
        }

        if (transform.eulerAngles.z >= xValueStart && transform.eulerAngles.z <= xValueEnd)
        {
            zValueAccepted = true;
        } else
        {
            zValueAccepted = false;
        }
    }
}
