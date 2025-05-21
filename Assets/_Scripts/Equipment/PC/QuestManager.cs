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
    
    void Start()
    {
        PickupController.InsertBattery += InsertBatteryQuestDone;
        testFormBatteryQuestTrigger.onClick.AddListener(TestFormBatteryQuestDone);
    }

    public void CollectVacuumQuestDone()
    {
        collectVacuumQuestResults?.Invoke();
        MailScreen.NewMailCount++;
    }
    
    private void InsertBatteryQuestDone()
    {
        insertBatteryQuestResults?.Invoke();
        MailScreen.NewMailCount++;
        PickupController.InsertBattery -= InsertBatteryQuestDone;
    }

    private void TestFormBatteryQuestDone()
    {
        testFormBatteryQuestResults?.Invoke();
        MailScreen.NewMailCount++;
    }
}
