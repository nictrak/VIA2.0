﻿using System.Collections;
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

    public QuestData Data { get => data; set => data = value; }
    public int CurrentProgress { get => currentProgress; set => currentProgress = value; }

    public void ReceiveMessage(string message)
    {
        if(message == data.TriggerMessage)
        {
            currentProgress += 1;
            if(currentProgress == data.GoalProgress)
            {
                for(int i = 0; i < data.MakeTrueAfterComplete.Count; i++)
                {
                    ConditionSystem.SetCondition(data.MakeTrueAfterComplete[i], true);
                }
                for (int i = 0; i < data.MakeFalseAfterComplete.Count; i++)
                {
                    ConditionSystem.SetCondition(data.MakeFalseAfterComplete[i], false);
                }
                QuestSystem.RemoveQuest(this);
            }
        }
    }
    public void ResetProgress()
    {
        currentProgress = data.InitialProgress;
    }
}