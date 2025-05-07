using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OvenPreset", menuName = "ScriptableObjects/OvenPreset")]
public class OvenPreset : ScriptableObject
{
    [Header("Battery Parameters")]
    public float temperature; // in Celsius

    public int cycles; // number of charge/discharge cycles

    public float voltage; // in Volts

    [Tooltip("Charge/Discharge rate relative to capacity")]
    public float cRate; // (Lade-)C-Rate
    
    public float EntladeCRate;
    
    public bool SoHAbbuch;
}
