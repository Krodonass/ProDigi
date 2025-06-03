using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public UnityEvent collectVacuumQuestResults;
    public UnityEvent insertBatteryQuestResults;
    public UnityEvent testFormBatteryQuestResults;

    [SerializeField] private Button testFormBatteryQuestTrigger;

    private bool _collectVacuumQuestFinished;
    private bool _insertBatteryQuestFinished;
    private bool _testFormBatteryQuestFinished;
    
    void Start()
    {
        PickupController.InsertBattery += InsertBatteryQuestDone;
        testFormBatteryQuestTrigger.onClick.AddListener(TestFormBatteryQuestDone);
    }

    public void CollectVacuumQuestDone()
    {
        if(_collectVacuumQuestFinished)
            return;
        
        collectVacuumQuestResults?.Invoke();
        MailScreen.NewMailCount++;
        _collectVacuumQuestFinished = true;
    }
    
    private void InsertBatteryQuestDone()
    {
        if (_insertBatteryQuestFinished)
            return;
        
        insertBatteryQuestResults?.Invoke();
        MailScreen.NewMailCount++;
        PickupController.InsertBattery -= InsertBatteryQuestDone;
        _insertBatteryQuestFinished = true;
    }

    private void TestFormBatteryQuestDone()
    {
        if(_testFormBatteryQuestFinished)
            return;
        
        testFormBatteryQuestResults?.Invoke();
        MailScreen.NewMailCount++;
        _testFormBatteryQuestFinished = true;
    }
}
