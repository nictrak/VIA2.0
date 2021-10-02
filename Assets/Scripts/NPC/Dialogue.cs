using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialogue : MonoBehaviour
{
    [SerializeField]
    protected string talkerName;
    [SerializeField]
    [Multiline]
    protected string dialogueContent;
    [SerializeField]
    protected bool isGoNext;
    [SerializeField]
    protected bool isDisplayIconLeft;
    [SerializeField]
    protected List<string> makeTrueConditionTopics;
    [SerializeField]
    protected List<string> makeFalseConditionTopics;
    [SerializeField]
    protected List<QuestData> assignedQuest;
    [SerializeField]
    protected bool isSendQuestMessage;
    public string TalkerName { get => talkerName; set => talkerName = value; }
    public string DialogueContent { get => dialogueContent; set => dialogueContent = value; }
    public bool IsDisplayIconLeft { get => isDisplayIconLeft; set => isDisplayIconLeft = value; }
    public bool IsGoNext { get => isGoNext; set => isGoNext = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract Dialogue GetNextDialogue(int param);
    public abstract List<string> GetChoicesString();
    public abstract bool IsClicknext();
    public void MakeConditionTrue()
    {
        for(int i = 0; i < makeTrueConditionTopics.Count; i++)
        {
            ConditionSystem.SetCondition(makeTrueConditionTopics[i], true);
        }
        for (int i = 0; i < makeFalseConditionTopics.Count; i++)
        {
            ConditionSystem.SetCondition(makeFalseConditionTopics[i], false);
        }
    }
    public abstract void StartDialogue();
    public abstract void EndDialogue();
    public void AssignQuest()
    {
        if(assignedQuest.Count > 0)
        {
            Debug.Log("Assign " + assignedQuest.Count);
        }
        for(int i = 0; i < assignedQuest.Count; i++)
        {
            QuestSystem.AddNewQuest(assignedQuest[i]);
        }
    }
    public void SendTalkQuestMessage()
    {
        if (isSendQuestMessage)
        {
            QuestSystem.SendQuestMessage("Talk " + talkerName);
        }
    }
}
