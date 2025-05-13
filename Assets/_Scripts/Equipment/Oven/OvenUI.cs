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

    public OvenPreset noFormat;

    public OvenUIFormatter ovenUIFormatter;
    
    private List<OvenPreset> currenPresetList;
    
    private int currentFormatIndex = -1;
    
    private int currentTestIndex = 0;

    public GameObject StartView;

    public GameObject FormatView;

    public GameObject ResultView;
    
    public GameObject InsertBatteriesView;

    private OvenPreset _formattedPreset;

    public void OpenStart()
    {
        PickupController.InsertBattery -= OpenStart;
        FormatView.SetActive(false);
        StartView.SetActive(true);
        ResultView.SetActive(false);
        InsertBatteriesView.SetActive(false);
    }

    public void OpenPresetView()
    {
        FormatView.SetActive(true);
        StartView.SetActive(false);
        ResultView.SetActive(false);
        InsertBatteriesView.SetActive(false);
    }

    public void OpenResultView(OvenPreset ovenPreset)
    {
        FormatView.SetActive(false);
        StartView.SetActive(false);
        ResultView.SetActive(true);
        InsertBatteriesView.SetActive(false);
        ResultView.GetComponent<OvenResultView>().LoadResult(ovenPreset);
    }
    
    public void SetTestMode()
    {
        if (currentFormatIndex < 0)
        {
            if (noFormat != null)
            {
                currenPresetList = noFormat.OvenTestList;
            }
        }
        else
        {
            currenPresetList = ovenFormatList[currentFormatIndex].OvenTestList;
        }
        LoadOvenPresets(currentTestIndex+1, currenPresetList[currentTestIndex]);
        OpenPresetView();
    }

    public void SetFormatMode()
    {
        currentFormatIndex = 0;
        currenPresetList = ovenFormatList;
        LoadOvenPresets(currentFormatIndex+1, currenPresetList[currentFormatIndex]);
        OpenPresetView();
    }

    private void Start()
    {
        //OpenStart();
        PickupController.InsertBattery += OpenStart;
    }

    public void LoadOvenPresets(int number, OvenPreset ovenPreset)
    {
        ovenUIFormatter.SetValues(number,ovenPreset);
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
            LoadOvenPresets(currentFormatIndex+1, currenPresetList[currentFormatIndex]);
        }
        else
        {
            currentTestIndex += 1;
            if (currentTestIndex >= currenPresetList.Count)
            {
                currentTestIndex = 0;
            }
            LoadOvenPresets(currentTestIndex+1, currenPresetList[currentTestIndex]);
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
            LoadOvenPresets(currentFormatIndex +1, currenPresetList[currentFormatIndex]);
        }
        else
        {
            currentTestIndex -= 1;
            if (currentTestIndex < 0)
            {
                currentTestIndex = currenPresetList.Count - 1;
            }
            LoadOvenPresets(currentTestIndex+1, currenPresetList[currentTestIndex]);   
        }
    }

    public void Reset()
    {
        OpenStart();
        currentFormatIndex = -1;
        _formattedPreset = null;
    }

    public void FormatBattery()
    {
        if (currenPresetList == ovenFormatList)
        {
            _formattedPreset = currenPresetList[currentFormatIndex];
            OpenResultView(currenPresetList[currentFormatIndex]);
        }
        else
        {
            OpenResultView(currenPresetList[currentTestIndex]);
        }
    }
}
