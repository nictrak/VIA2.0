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
}
