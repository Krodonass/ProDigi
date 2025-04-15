using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    public bool electolytAssembled;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ElectrolyteAssembly")
        {
            electolytAssembled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      Destroy(drop);
    }
}
