using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    
    public GameObject CloseDoorView;
    
    public bool Batteryinserted = false;

    public Doors OvenDoor;

    private OvenPreset _formattedPreset = null;

    [SerializeField] private UnityEngine.UI.Button FormButton;
    
    [SerializeField] private UnityEngine.UI.Button TestButton;

    public void OpenStart()
    {
        FormatView.SetActive(false);
        StartView.SetActive(true);
        ResultView.SetActive(false);
        InsertBatteriesView.SetActive(false);
        CloseDoorView.SetActive(false);
    }

    public void OpenPresetView()
    {
        FormatView.SetActive(true);
        StartView.SetActive(false);
        ResultView.SetActive(false);
        InsertBatteriesView.SetActive(false);
        CloseDoorView.SetActive(false);
    }

    public void OpenResultView(OvenPreset ovenPreset)
    {
        FormatView.SetActive(false);
        StartView.SetActive(false);
        ResultView.SetActive(true);
        InsertBatteriesView.SetActive(false);
        CloseDoorView.SetActive(false);
        ResultView.GetComponent<OvenResultView>().LoadResult(ovenPreset);
    }
    
    public void SetTestMode()
    {
        if (_formattedPreset == null)
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

    public void DeactivateForm()
    {
        if (FormButton != null)
        {
            FormButton.interactable = false;
        }
    }

    public void AcivateForm()
    {
        if (FormButton != null)
        {
            FormButton.interactable = true;
        }
    }

    public void DeactivateTest()
    {
        if (TestButton != null)
        {
            TestButton.interactable = false;
        }
    }

    public void AcivateTest()
    {
        if (TestButton != null)
        {
            TestButton.interactable = true;
        }
    }

    public void OnOpenDoorHandler(Boolean isOpen)
    {
        print("IS OPEN");
        if (Batteryinserted)
        {
            if (isOpen)
            {
                CloseDoorView.SetActive(true);
                FormatView.SetActive(false);
                StartView.SetActive(false);
                ResultView.SetActive(false);
                InsertBatteriesView.SetActive(false);
            }
            else
            {
                CloseDoorView.SetActive(false);
                FormatView.SetActive(false);
                StartView.SetActive(true);
                ResultView.SetActive(false);
                InsertBatteriesView.SetActive(false);
            }
        }
    }

    public void OnInsertBatterieHandler()
    {
        print("Insert Battery");
        Batteryinserted = true;
        PickupController.InsertBattery -= OnInsertBatterieHandler;
        CloseDoorView.SetActive(true);
        FormatView.SetActive(false);
        StartView.SetActive(false);
        ResultView.SetActive(false);
        InsertBatteriesView.SetActive(false);
    }

    private void Start()
    {
        //OpenStart();
        PickupController.InsertBattery += OnInsertBatterieHandler;
        OvenDoor.OnOpenDoor += OnOpenDoorHandler;
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
        currentTestIndex = 0;
        _formattedPreset = null;
        AcivateTest();
        AcivateForm();
    }

    public void FormatBattery()
    {
        print("FORMieren!");
        if (currenPresetList == ovenFormatList)
        {
            _formattedPreset = currenPresetList[currentFormatIndex];
            OpenResultView(currenPresetList[currentFormatIndex]);
            DeactivateForm();
        }
        else
        {
            OpenResultView(currenPresetList[currentTestIndex]);
            DeactivateForm();
            DeactivateTest();
        }
    }
}
