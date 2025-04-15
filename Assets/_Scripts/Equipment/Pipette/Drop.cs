using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    public bool electolytAssembled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ElectrolyteAssembly")
        {
            if (GameManager.Instance.patCellElectrolyteAssemblyPossibleGameManager)
            {
                electolytAssembled = true;
                GameManager.Instance.electrolyAssembledGameManager = true;
                GameManager.Instance.patCellUpperCathodeAssemblyPossibleGameManager = true;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
      Destroy(drop);
        
    }
}
