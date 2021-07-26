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
    public static void AddNewQuest(QuestData questData)
    {
        Quest quest = new Quest(questData);
        Quests.Add(quest);
    }
    public static void RemoveQuest(Quest quest)
    {
        Quests.Remove(quest);
    }
    public static void SendQuestMessage(string message)
    {
        for(int i = 0; i < Quests.Count; i++)
        {
            Quests[i].ReceiveMessage(message);
        }
    }
    public static string GetTopQuestDescription()
    {
        if (Quests == null) return "";
        if (Quests.Count == 0) return "";
        return Quests[0].Data.Description + " ("+ Quests[0].CurrentProgress + "/"+ Quests[0].Data.GoalProgress +")";
    }
}
