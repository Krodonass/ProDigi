using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "OvenResult", menuName = "ScriptableObjects/OvenResult")]
public class OvenResult : ScriptableObject
{
    public string header;
    
    [TextArea]
    public string description;
    
    public Color color;
}
