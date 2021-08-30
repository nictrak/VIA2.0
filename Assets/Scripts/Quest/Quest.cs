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

    public QuestData Data { get => data; set => data = value; }
    public int CurrentProgress { get => currentProgress; set => currentProgress = value; }

    public void ReceiveMessage(string message, bool isSetProgress = false, int newProgress = 0)
    {
        if(message == data.TriggerMessage)
        {
            if (isSetProgress)
            {
                currentProgress = newProgress;
            }
            else
            {
                currentProgress += 1;
            }
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
                GiveReward();
                ConditionSystem.SetCondition("IsCompleted " + data.name, true);
                QuestSystem.RemoveQuest(this);
                if (Data.NextQuest != null)
                {
                    int newQuestIndex = QuestSystem.AddNewQuest(Data.NextQuest);
                    QuestPanel.SetIndex(newQuestIndex);
                }
            }
        }
    }
    public void ResetProgress()
    {
        currentProgress = data.InitialProgress;
    }
    private void GiveReward()
    {
        Inventory inventory = Resources.FindObjectsOfTypeAll<Inventory>()[0];
        for (int i = 0; i < data.QuestRewards.Count; i++)
        {
            for (int j = 0; j < data.RewardNumbers[i]; j++)
            {
                inventory.AddItem(data.QuestRewards[i]);
            }
        }
    }
}