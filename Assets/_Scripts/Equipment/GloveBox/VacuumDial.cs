using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumDial : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject Dial;

    public bool isEvacuated;
    public bool isFlooded;

    public bool isEvactuating;
    public bool isFlooding;

    public bool sound;

    public float air = 0;
    public float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        sound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().isEvacuatingGameManager)
        {
            Evacuate();
            if (sound)
            {
                FindAnyObjectByType<AudioManager>().Play("Flood_Evacuate");
                sound = false;
            }
        }   

        if (gameManager.GetComponent<GameManager>().isFloodingGameManager)
        {
            Flood();
            if (sound)
            {
                FindAnyObjectByType<AudioManager>().Play("Flood_Evacuate");
                sound = false;
            }

        }

        if (air <= -180)
        {
            isEvacuated = true;
            sound = true;

        } 

        if (isEvacuated) {
            isFlooded = false;
        }

        if (air >= 0)
        {
            isEvacuated = false;
            isFlooded = true;
        }
    }

    void Evacuate()
    {
        if ( air >= -180)
        {
            Vector3 newRotation = new Vector3(0, 0, air);
            transform.localEulerAngles = newRotation;
            air-= 0.1f;
        }
    }

    void Flood()
    {
        if (air <= 0)
        {
            Vector3 newRotation = new Vector3(0, 0, air);
            transform.localEulerAngles = newRotation;
            air += 0.1f;
        }
    }
}
