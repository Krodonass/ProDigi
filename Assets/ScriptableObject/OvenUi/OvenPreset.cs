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
    
    [Header("Battery Parameters")]
    public float temperature; // in Celsius

    public int cycles; // number of charge/discharge cycles

    public float voltageStart; // in Volts
    public float voltageEnd;

    [Tooltip("Charge/Discharge rate relative to capacity")]
    public float chargeCRate; // (Lade-)C-Rate
    
    public float DischargeCRate;
    
    public SoHStates SoHStop;

    public string ResultHeadline;

    public string ResultDescription;
}
