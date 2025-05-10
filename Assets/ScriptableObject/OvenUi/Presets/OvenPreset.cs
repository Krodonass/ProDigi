using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum SoHStates
{
    YES,
    NO,
    NA,
};


[CreateAssetMenu(fileName = "OvenPreset", menuName = "ScriptableObjects/OvenPreset")]
public class OvenPreset : ScriptableObject
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
    
    public List<OvenResult> OvenResultList;
}
