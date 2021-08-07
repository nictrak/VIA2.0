using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherReporter : MonoBehaviour
{
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private int reportFrame;
    private int frameCounter;
    // Start is called before the first frame update
    void Start()
    {
        frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCounter >= reportFrame)
        {
            for(int i = 0; i < QuestSystem.Quests.Count; i++)
            {
                if (QuestSystem.Quests[i].Data.TriggerMessage.StartsWith("Gather"))
                {
                    string[] messages = QuestSystem.Quests[i].Data.TriggerMessage.Split(' ');
                    int result = inventoryManager.CountItem(messages[1]);
                    QuestSystem.SendQuestMessage(QuestSystem.Quests[i].Data.TriggerMessage, true, result);
                }
            }
            frameCounter = 0;
        }
        else
        {
            frameCounter++;
        }
    }
}
