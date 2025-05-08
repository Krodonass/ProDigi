using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OvenUIFormatter : MonoBehaviour
{
    public TextMeshProUGUI PresetName;
    public TextMeshProUGUI Cycles;
    public TextMeshProUGUI ChargeCRate;
    public TextMeshProUGUI DischargeCRate;
    public TextMeshProUGUI VoltageRange;
    public TextMeshProUGUI Temperatur;
    public TextMeshProUGUI SoHStopAt80;

    public TextMeshProUGUI ConclusionHeadLine;
    public TextMeshProUGUI ConcilusionDescription;


    public void SetValues(OvenPreset preset)
    {
        Cycles.text = preset.cycles.ToString();
        ChargeCRate.text = preset.chargeCRate.ToString() + "C";
        DischargeCRate.text = preset.DischargeCRate.ToString() + "C";
        VoltageRange.text = preset.voltageStart.ToString() + "V - " + preset.voltageEnd.ToString() + "V";
        Temperatur.text = preset.temperature.ToString() + "°C";
        switch (preset.SoHStop)
        {
            case SoHStates.YES:
                SoHStopAt80.text = "Yes";
                break;
            case SoHStates.NO:
                SoHStopAt80.text = "Yes";
                break;
            case SoHStates.NA:
                SoHStopAt80.text = "N/A";
                break;

        }
    }
}
