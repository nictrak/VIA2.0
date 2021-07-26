using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private int currentProgress;
    private QuestData data;

    public Quest(QuestData questData)
    {
        data = questData;
        currentProgress = data.InitialProgress;
    }

    public void ReceiveMessage(string message)
    {
        if(message == data.TriggerMessage)
        {
            currentProgress += 1;
            if(currentProgress == data.GoalProgress)
            {
                QuestSystem.RemoveQuest(this);
            }
        }
    }
    public void ResetProgress()
    {
        currentProgress = data.InitialProgress;
    }
}