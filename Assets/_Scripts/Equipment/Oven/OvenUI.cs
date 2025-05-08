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
    public List<OvenPreset> ovenFormatList = new List<OvenPreset>();
    
    public List<OvenPreset> ovenTestList = new List<OvenPreset>();

    public OvenUIFormatter ovenUIFormatter;
    
    private List<OvenPreset> currenPresetList;
    
    private int currentFormatIndex = 0;
    
    private int currentTestIndex = 0;

    public GameObject StartView;

    public GameObject FormatView;

    public GameObject FormatResult;

    private OvenPreset _formattedPreset;
    

    public void OpenStart()
    {
        FormatView.SetActive(false);
        StartView.SetActive(true);
        FormatResult.SetActive(false);
    }

    public void OpenPresetView()
    {
        FormatView.SetActive(true);
        StartView.SetActive(false);
        FormatResult.SetActive(false);
    }

    public void OpenResultView(OvenPreset ovenPreset)
    {
        FormatView.SetActive(false);
        StartView.SetActive(false);
        FormatResult.SetActive(true);
    }
    
    public void SetTestMode()
    {
        currenPresetList = ovenTestList;
        LoadOvenPresets(currenPresetList[currentTestIndex]);
        OpenPresetView();
    }

    public void SetFormatMode()
    {
        currenPresetList = ovenFormatList;
        LoadOvenPresets(currenPresetList[currentFormatIndex]);
        OpenPresetView();
    }

    private void Start()
    {
        SetFormatMode();
    }

    public void LoadOvenPresets(OvenPreset ovenPreset)
    {
        ovenUIFormatter.SetValues(ovenPreset);
    }

    public void NextPreset()
    {
        if (currenPresetList == ovenFormatList)
        {
            currentFormatIndex += 1;
            if (currentFormatIndex >= currenPresetList.Count)
            {
                currentFormatIndex = 0;
            }
            LoadOvenPresets(currenPresetList[currentFormatIndex]);
        }
        else
        {
            currentTestIndex += 1;
            if (currentTestIndex >= currenPresetList.Count)
            {
                currentTestIndex = 0;
            }
            LoadOvenPresets(currenPresetList[currentTestIndex]);
        }

    }
    
    public void PreviouslyPreset()
    {
        if (currenPresetList == ovenFormatList)
        {
            currentFormatIndex -= 1;
            if (currentFormatIndex < 0)
            {
                currentFormatIndex = currenPresetList.Count - 1;
            }
            LoadOvenPresets(currenPresetList[currentFormatIndex]);
        }
        else
        {
            currentTestIndex -= 1;
            if (currentTestIndex < 0)
            {
                currentTestIndex = currenPresetList.Count - 1;
            }
            LoadOvenPresets(currenPresetList[currentTestIndex]);   
        }
    }

    public void Reset()
    {
        
    }

    public void FormatBattery()
    {
        if (currenPresetList == ovenFormatList)
        {
            _formattedPreset = currenPresetList[currentFormatIndex];
        }
        else
        {
            
        }
    }
}
