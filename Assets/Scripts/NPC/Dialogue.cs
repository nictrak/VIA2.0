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
    protected List<string> makeTrueConditionTopics;
    public string TalkerName { get => talkerName; set => talkerName = value; }
    public string DialogueContent { get => dialogueContent; set => dialogueContent = value; }
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
    }
}
