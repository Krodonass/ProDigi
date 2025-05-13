using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "OvenResult", menuName = "ScriptableObjects/OvenResult")]
public class OvenResult : ScriptableObject
{
    
    public string presetName;
    
    public int cycles; // number of charge/discharge cycles

    [Tooltip("Charge/Discharge rate relative to capacity")]
    public float chargeCRate; // (Lade-)C-Rate
    
    public float DischargeCRate;
    
    public float voltageStart; // in Volts
    public float voltageEnd;
    
    [Header("Battery Parameters")]
    public float temperature; // in Celsius
    
    public SoHStates SoHStop;
    
    public string header;
    
    [TextArea]
    public string description;
    
    public Color color;
    
    public List<OvenResult> OvenResultList;
}
