using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OvenModi
{
    Formieren,
    Test
}

public class OvenUI : MonoBehaviour
{
    public List<OvenPreset> OvenPresetList = new List<OvenPreset>();
    
    private int CurrentOvenIndex = 0;
    
    public OvenModi OvenModus = OvenModi.Formieren;

    private void Start()
    {
        LoadOvenPresets(GameManager.Instance.CurrentOvenPreset);
    }

    public void LoadOvenPresets(OvenPreset ovenPreset)
    {
        
    }

    public void NextPreset()
    {
        CurrentOvenIndex += 1;
        if (CurrentOvenIndex >= OvenPresetList.Count)
        {
            CurrentOvenIndex = 0;
        }
        LoadOvenPresets(OvenPresetList[CurrentOvenIndex]);
        GameManager.Instance.CurrentOvenPreset = OvenPresetList[CurrentOvenIndex];
    }
    
    public void PreviouslyPreset()
    {
        CurrentOvenIndex -= 1;
        if (CurrentOvenIndex < 0)
        {
            CurrentOvenIndex = OvenPresetList.Count - 1;
        }
        LoadOvenPresets(OvenPresetList[CurrentOvenIndex]);
        GameManager.Instance.CurrentOvenPreset = OvenPresetList[CurrentOvenIndex];
    }
}
