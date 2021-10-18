using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static List<Quest> Quests;
    // Start is called before the first frame update
    void Start()
    {
        if(Quests == null)
        {
            Quests = new List<Quest>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // return added index
    public static int AddNewQuest(QuestData questData)
    {
        Quest quest = new Quest(questData);
        Quests.Add(quest);
        ConditionSystem.SetCondition("IsAssigned " + questData.name, true);
        return Quests.Count - 1;
    }
    public static void RemoveQuest(Quest quest)
    {
        Quests.Remove(quest);
    }
    public static void SendQuestMessage(string message, bool isSetProgress = false, int newProgress = 0)
    {
        for(int i = 0; i < Quests.Count; i++)
        {
            Quests[i].ReceiveMessage(message, isSetProgress, newProgress);
        }
    }
    public static string GetTopQuestDescription()
    {
        if (Quests == null) return "";
        if (Quests.Count == 0) return "";
        return Quests[0].Data.Description + " ("+ Quests[0].CurrentProgress + "/"+ Quests[0].Data.GoalProgress +")";
    }
    public static string GetQuestDescriptionFromIndex(int index)
    {
        if (Quests == null) return "";
        if (Quests.Count <= index) return "";
        return Quests[index].Data.Description + " (" + Quests[index].CurrentProgress + "/" + Quests[index].Data.GoalProgress + ")";
    }
    public static int GetQuestsCount()
    {
        if (Quests == null) return 0;
        else return Quests.Count;
    }
}
